using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AntDesign;
using System;
using System.Threading.Tasks;
using PaginaEEST1.Data.Models.Images;
using PaginaEEST1.Data.Enums;

﻿namespace PaginaEEST1.Helpers
{
    public static class ImageUploadHelper
    {
        public static async Task<string> StreamToBase64(InputFileChangeEventArgs e)
        {
            //Para guardar imagenes las guardamos en base64 y para esto necesitamos un array para hacer la conversion
            Stream stream = e.File.OpenReadStream();
            return Convert.ToBase64String(await StreamToArrayAsync(stream));
        }

        private static async Task<byte[]> StreamToArrayAsync(Stream stream)
        {
            //Este metodo convierte un stream en un array para que despues se convierta en un base64
            byte[] bytes = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int leer;
                while ((leer = await stream.ReadAsync(bytes, 0, bytes.Length)) > 0)
                {
                    ms.Write(bytes, 0, leer);
                }
                return ms.ToArray();
            }
        }
    }
}