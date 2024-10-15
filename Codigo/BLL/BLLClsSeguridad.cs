using System;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
    public static class BLLClsSeguridad
    {
        public static string GenerarSHA(string sCadena)
        {
            try
            {
                // Crear un objeto de codificación para garantizar el estándar de codificación para el texto fuente
                UnicodeEncoding ueCodigo = new UnicodeEncoding();
                // Recuperar una matriz de bytes basado en el texto de origen
                byte[] ByteSourceText = ueCodigo.GetBytes(sCadena);
                // Instanciar un objeto SHA1CryptoServiceProvider
                SHA1CryptoServiceProvider SHA = new SHA1CryptoServiceProvider();
                // Calcular el valor hash SHA-1 de la fuente
                byte[] ByteHash = SHA.ComputeHash(ByteSourceText);
                // Convertir a formato de cadena para el retorno
                return Convert.ToBase64String(ByteHash);
            }
            catch (CryptographicException ex)
            {
                // Manejar excepción criptográfica
                throw ex;
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción
                throw ex;
            }
        }
    }
}