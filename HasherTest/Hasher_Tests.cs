using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Wishart.Hasher;
using System.Security.Cryptography;

namespace HasherTest
{
    public class Hasher_Tests
    {

        [Fact]
        public static void IsHasherRegistered_RegisteredHasher1_ReturnsTrue() {
            Assert.True( Hasher.IsHasherRegistered( "SHA1" ) );
        }

        [Fact]
        public static void IsHasherRegistered_RegisteredHasher2_ReturnsTrue() {
            Assert.True( Hasher.IsHasherRegistered( "SHA256" ) );
        }

        [Fact]
        public static void IsHasherRegistered_RegisteredHasher3_ReturnsTrue() {
            Assert.True( Hasher.IsHasherRegistered( "SHA512" ) );
        }

        [Fact]
        public static void IsHasherRegistered_RegisteredHasher4_ReturnsTrue() {
            Assert.True( Hasher.IsHasherRegistered( "MD5" ) );
        }

        [Fact]
        public static void IsHasherRegistered_UnregisteredHashName_ReturnsFalse() {
            var unregisteredHashName = "UNREGISTERED";

            Assert.False( Hasher.IsHasherRegistered( unregisteredHashName ) );
        }

        [Fact]
        public static void IsHasherRegistered_NullHashName_ThrowException() {
            Assert.Throws<ArgumentException>( () => Hasher.IsHasherRegistered( null ) );
        }

        [Fact]
        public static void IsHasherRegistered_EmtpyHashName_ThrowException() {
            Assert.Throws<ArgumentException>( () => Hasher.IsHasherRegistered( string.Empty ) );
        }

        [Fact]
        public static void GetRegisteredKeys_Returns4Keys() {
            Assert.Equal( 4, Hasher.GetRegisteredKeys().Count );
        }

        [Fact]
        public static void Constructor_AvailableHasherNameGiven_HasherNameSetupCorrectly() {
            string existingHasherName = "MD5";

            Hasher newHasher = new Hasher( existingHasherName );

            Assert.True( newHasher.HasherName.Equals( existingHasherName, StringComparison.OrdinalIgnoreCase ) );
        }

        [Fact]
        public static void Constructor_UnregistieredHasherNameGiven_ThrowsException() {
            string unregisteredHasherName = "UNREGISTERED";

            Assert.Throws<ArgumentException>( () => new Hasher( unregisteredHasherName ) );
        }
    }
}
