using System;
using System.Security.Cryptography;
using System.Text;

namespace Library.Api.Util
{
    class GenericHash
    {
        private static HashAlgorithm _algoritmo;
        public GenericHash(HashAlgorithm algoritmo)
        {
            _algoritmo = algoritmo;
        }

        public static string GerarHash(string senha)
        {
            var valorCodificado = Encoding.UTF8.GetBytes(senha);
            var senhaCifrada = _algoritmo.ComputeHash(valorCodificado);
            var sb = new StringBuilder();
            foreach (var caractere in senhaCifrada)
            {
                sb.Append(caractere.ToString("X2"));
            }
            return sb.ToString();
        }
        public static string VerificarHash(string senhaDigitada)
        {
            if (string.IsNullOrEmpty(senhaDigitada))
                throw new NullReferenceException("Cadastre uma senha.");
            var senhaCifrada = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));
            var sb = new StringBuilder();
            foreach (var caractere in senhaCifrada)
            {
                sb.Append(caractere.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
