using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;

namespace Wishart.Hasher
{
    public class Hasher
    {
        // Member Variables
        //

        private static IDictionary<string, Type> _registered = new Dictionary<string, Type>();
        private string _hasherName = "SHA256";


        // Properties
        //

        public string HasherName {
            get {
                return _hasherName;
            }
            set {
                if ( false == Hasher.IsHasherRegistered( value ) ) {
                    throw new ArgumentException( "hasherName is not the name of a registered HashingAlgorithm" );
                }

                this._hasherName = value;
            }
        }


        // Static Constructor
        //

        static Hasher() {
            Hasher.Register<SHA1CryptoServiceProvider>( "SHA1" );
            Hasher.Register<SHA256CryptoServiceProvider>( "SHA256" );
            Hasher.Register<SHA512CryptoServiceProvider>( "SHA512" );
            Hasher.Register<MD5CryptoServiceProvider>( "MD5" );
        }

        
        // Constructor
        //

        public Hasher() { }

        public Hasher(string hasherName) {
            this.HasherName = hasherName;
        }


        // Instance Methods
        //
        
        public string Hash( string content ) {
            return Hasher.Hash( content, Hasher.GetHashAlgorithm( _hasherName ) );
        }

        public string Hash( byte [] content ) {
            return Hasher.Hash( content, Hasher.GetHashAlgorithm( _hasherName ) );
        }


        // Static Methods
        //

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

        public static bool IsHasherRegistered( string hasherName ) {
            if ( String.IsNullOrEmpty( hasherName ) )
                throw new ArgumentException( "hasherName cannot be null or an empty string" );

            foreach ( KeyValuePair<string, Type> item in _registered ) {
                if ( item.Key.Equals(hasherName, StringComparison.OrdinalIgnoreCase) ) {
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

        public static string Hash( byte[] buffer, HashAlgorithm hashAlgorithm ) {
            return BitConverter.ToString(
                hashAlgorithm.ComputeHash( buffer ) ).Replace( "-", "" ).ToLower();
        }

        // TODO: replace GetBytes() with StringToBytes()
        public static string Hash( string content, HashAlgorithm hashAlgorithm ) {
            return Hash( ASCIIEncoding.ASCII.GetBytes( content ), hashAlgorithm);
        }

        public static byte [] StringToBytes( string content ) {
            return UnicodeEncoding.UTF8.GetBytes( content );
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
