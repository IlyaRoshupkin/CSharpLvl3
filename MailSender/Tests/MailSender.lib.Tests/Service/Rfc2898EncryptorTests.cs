using MailSender.lib.Interfaces;
using MailSender.lib.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MailSender.lib.Tests.Service
{
    [TestClass]
    class Rfc2898EncryptorTests
    {
        private IEncryptorService _Encryptor = 
            new Rfc2898Encryptor();
        static Rfc2898EncryptorTests()
        {

        }
        public Rfc2898EncryptorTests() { }
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext Context)
        {

        }
        [ClassInitialize]
        public static void ClassInitialize(TestContext Context)
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {

        }
        [TestCleanup]
        public void TestCleanup()
        {

        }
        [ClassCleanup]
        public void ClassCleanup()
        {

        }
        [AssemblyCleanup]
        public void AssemblyCleanup()
        {

        }
        [TestMethod]
        public void Encrypt_Hello_World_and_Decrypt()
        {
            const string str = "Hello World!";
            const string password = "Password";

            var encrypted_str = _Encryptor.Encrypt(str, password);

            var decrypted_str = _Encryptor.Decrypt(encrypted_str, password);
            Assert.AreEqual(str, encrypted_str);
            Assert.AreEqual(str, decrypted_str);
        }
        [TestMethod, ExpectedException(typeof(CryptographicException))]
        public void Wrong_Decryption_thrown_CryptographicException()
        {
            const string str = "Hello World!";
            const string password = "Password";
            var encrypted_str = _Encryptor.Encrypt(str, password);
            var wrong_pass_decrypted = _Encryptor.Decrypt(encrypted_str, "qwe");
        }
    }
}
