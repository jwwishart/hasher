using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;

namespace Hasher
{
    class Program
    {
        private class Settings
        {
            public string Mode { get; set; }
            public byte [] Buffer { get; set; }
        }

        static void Main( string [] args ) {
            byte [] buffer = null;
            string mode = "SHA256";
            bool isFile = false;

            if ( 0 == args.Length ) {
                PrintHelp();
                return;
            }

            if ( "help /? --help".Split( ' ' ).Contains( args [0], new StringComparer() ) ) {
                PrintHelp();
                return;
            }

            if ( 1 == args.Length ) {
                if ( Hasher.IsHasherRegistered( args [0] ) ) {
                    mode = args [0];
                } else {
                    try {
                        buffer = File.ReadAllBytes( args [0] );
                        isFile = true;
                    } catch ( Exception ex ) {
                        Console.WriteLine( "Error trying to open file: " + args [0] );
                        return;
                    }
                }
            }

            if ( 2 == args.Length ) {
                if ( args [0].Equals( "/t", StringComparison.OrdinalIgnoreCase ) ) {
                    buffer = ASCIIEncoding.ASCII.GetBytes( args [1] );
                    isFile = false;
                } else {
                    if ( Hasher.IsHasherRegistered( args [0] ) ) {
                        mode = args [0];

                        try {
                            buffer = File.ReadAllBytes( args [1] );
                            isFile = true;
                        } catch ( Exception ex ) {
                            Console.WriteLine( "Error trying to open file: " + args [1] );
                            return;
                        }
                    } else {
                        Console.WriteLine( "You didn't provide a valid hash name" );
                        return;
                    }
                }
            }

            if ( 3 == args.Length ) {
                if ( Hasher.IsHasherRegistered( args [0] ) ) {
                    mode = args [0];
                } else {
                    Console.WriteLine( "You didn't provide a valid hash name" );
                    return;
                } 

                if ( args [1].Equals( "/t", StringComparison.OrdinalIgnoreCase ) ) {
                    buffer = ASCIIEncoding.ASCII.GetBytes( args [2] );
                    isFile = false;
                } else {
                    Console.WriteLine( "You didn't provide the /t option" );
                    return;
                }
            }

            Console.WriteLine( "Hash Used: " + mode );
            Console.WriteLine( "File: " + (isFile ? "Yes" : "No"));

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Hasher.Hash( buffer, Hasher.GetHashAlgorithm( mode ) ));
            Console.ResetColor();
        }


        private static FileStream CreateFileStreamIfAvailable( string [] args ) {
            foreach ( string arg in args ) {
                if ( arg.ToLower().IndexOf( "file:" ) == 0 ) {
                    if ( arg.Length <= 5 )
                        throw new ArgumentException( "filename not provided." );

                    var filename = arg.Substring( 5 );
                    if ( false == File.Exists( filename ) ) {
                        throw new ArgumentException( "file does not exist: " + filename );
                    }

                    return File.OpenRead( filename );
                }
            }

            return null;
        }

        private static void PrintHelp() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( "Hasher Utility" );
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write( "Author: " );
            Console.ResetColor();
            Console.WriteLine( "Justin Wishart" );

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write( "Version: " );
            Console.ResetColor();
            Console.WriteLine( "0.3" );

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write( "Website: " );
            Console.ResetColor();
            Console.WriteLine( "http://jwwishart.blogspot.com" );
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine( "Usage:" );
            Console.ResetColor();
            Console.WriteLine( "hasher [HashAlgorithm] [<filename> | /t <content>]\n" );

            Console.WriteLine( "help /? --help   This help content" );
            Console.WriteLine( "filename         The path to the file that you want hashed" );
            Console.WriteLine( "/t               Indicates <content> should be hashed" );
            Console.WriteLine( "content          The string that you want hashed (should have /t before it)" );
            
            Console.WriteLine( "HashAlgorithm    Hash functions available (See Below)" );
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine( "Available Hash Algorithms:" );
            Console.ResetColor();
            Console.WriteLine( "- Sha1" );
            Console.WriteLine( "- Sha256" );
            Console.WriteLine( "- Sha512" );
            Console.WriteLine( "- MD5" );
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine( "Examples:" );
            Console.ResetColor();
            Console.WriteLine( "hasher junk.txt" );
            Console.WriteLine( "hasher /t hash-this-string" );
            Console.WriteLine( "hasher SHA256 junk.txt" );
            Console.WriteLine( "hasher SHA1 /t hash-this-string" );
            Console.WriteLine( "hasher MD5 hash-this-string" );
            Console.WriteLine();
            Console.WriteLine( "Default hash algorithm is SHA256" );
        }

    }
}
