﻿using Microsoft.AspNetCore.Http;

namespace ProductMiniApi.Repository.Abastract
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }
}
