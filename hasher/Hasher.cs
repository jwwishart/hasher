using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;

namespace Hasher
{
    public class Hasher
    {
        private static IDictionary<string, Type> _registered = new Dictionary<string, Type>();

        public static void Register<T>( string hasherName ) where T:HashAlgorithm {
            if ( String.IsNullOrEmpty( hasherName ) )
                throw new ArgumentException( "key cannot be empty" );

            _registered.Add( hasherName, typeof(T) );
        }

        public static void Unregister( string hasherName ) {
            foreach ( KeyValuePair<string, Type> item in _registered ) {
                if ( item.Key == hasherName ) {
                    _registered.Remove( item.Key );
                    return;
                }
            }
        }

        //public static void Unregister<T>() where T : HashAlgorithm {
        //    foreach ( KeyValuePair<string, Type> item in _registered ) {
        //        if ( item.Value.FullName == typeof( T ).FullName ) {
        //            _registered.Remove( item.Key );
        //            return;
        //        }
        //    }
        //}

        public static bool IsHasherRegistered( string key ) {
            foreach ( KeyValuePair<string, Type> item in _registered ) {
                if ( item.Key.Equals(key, StringComparison.OrdinalIgnoreCase) ) {
                    return true;
                }
            }

            return false;
        }

        public static ICollection<string> GetRegisteredKeys() {
            return _registered.Keys;
        }

        //public static bool IsHasherRegistered<T>() where T:HashAlgorithm {
        //    foreach ( KeyValuePair<string, Type> item in _registered ) {
        //        if ( item.Key == key ) {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        static Hasher() {
            Hasher.Register<SHA1CryptoServiceProvider>( "SHA1" );
            Hasher.Register<SHA256CryptoServiceProvider>( "SHA256" );
            Hasher.Register<SHA512CryptoServiceProvider>( "SHA512" );
            Hasher.Register<MD5CryptoServiceProvider>( "MD5" );
        }

        public static string Hash( byte[] buffer, HashAlgorithm hashAlgorithm ) {
            return BitConverter.ToString(
                hashAlgorithm.ComputeHash( buffer ) ).Replace( "-", "" ).ToLower();
        }

        public static string Hash( string content, HashAlgorithm hashAlgorithm ) {
            return Hash( ASCIIEncoding.ASCII.GetBytes( content ), hashAlgorithm);
        }

        public static HashAlgorithm GetHashAlgorithm( string key ) {
            foreach ( KeyValuePair<string, Type> item in _registered ) {
                if ( item.Key.Equals(key, StringComparison.OrdinalIgnoreCase)) {
                    var type = item.Value;
                    ConstructorInfo constructor =
                        type.GetConstructor( new Type [0] );
                    return (HashAlgorithm)constructor.Invoke(new object[0]);
                }
            }

            return null;
        }
    }
}
