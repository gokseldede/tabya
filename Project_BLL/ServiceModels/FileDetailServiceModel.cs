﻿using System;

namespace Project_BLL.ServiceModels
{
    public class FileDetailServiceModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
    }
}