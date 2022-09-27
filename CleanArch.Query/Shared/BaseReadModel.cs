﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Shared
{
    public class BaseReadModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}