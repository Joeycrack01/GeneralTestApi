using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.KeyVaultTest
{
    public interface IKeyVaultTestService
    {
        Task<string> DecryptStringAsync(CryptographyClient cryptoClient, string input);
        Task<string> EncryptDecryptAsync();
        Task<string> EncryptStringAsync(CryptographyClient cryptoClient, string input);
    }

    public class KeyVaultTestService : IKeyVaultTestService
    {
        public KeyVaultTestService()
        {

        }

        public async Task<string> EncryptDecryptAsync()
        {
            //string keyVaultName = "myfavouritekeyvault";
            string keyVaultUri = "https://joeycrackvault.vault.azure.net";
            string keyVaultKeyName = "TestVaultKey";
            string textToEncrypt = "StuffIDoNotWantYouToKnow";


            var client = new KeyClient(new Uri(keyVaultUri), new DefaultAzureCredential());

            await client.CreateRsaKeyAsync(new CreateRsaKeyOptions(keyVaultKeyName)).ConfigureAwait(false);

            KeyVaultKey key = await client.GetKeyAsync(keyVaultKeyName).ConfigureAwait(false);

            var cryptoClient = new CryptographyClient(key.Id, new DefaultAzureCredential());

            string encryptedString = await EncryptStringAsync(cryptoClient, textToEncrypt).ConfigureAwait(false);

            Console.WriteLine($"Encrypted string: {encryptedString}");
            return $"Encrypted string: {encryptedString}";

            //string decryptedString = await DecryptStringAsync(cryptoClient, encryptedString).ConfigureAwait(false);

            //Console.WriteLine($"Decrypted string: {decryptedString}");
            //return $"Decrypted string: {decryptedString}";
        }

        //public string GatewayName = "Premium Payment Gateway";


        public async Task<string> EncryptStringAsync(CryptographyClient cryptoClient, string input)
        {
            byte[] inputAsByteArray = Encoding.UTF8.GetBytes(input);

            EncryptResult encryptResult = await cryptoClient.EncryptAsync(EncryptionAlgorithm.RsaOaep, inputAsByteArray).ConfigureAwait(false);

            return Convert.ToBase64String(encryptResult.Ciphertext);
        }

        public async Task<string> DecryptStringAsync(CryptographyClient cryptoClient, string input)
        {
            byte[] inputAsByteArray = Convert.FromBase64String(input);

            DecryptResult decryptResult = await cryptoClient.DecryptAsync(EncryptionAlgorithm.RsaOaep, inputAsByteArray).ConfigureAwait(false);

            return Encoding.Default.GetString(decryptResult.Plaintext);
        }
    }
}
