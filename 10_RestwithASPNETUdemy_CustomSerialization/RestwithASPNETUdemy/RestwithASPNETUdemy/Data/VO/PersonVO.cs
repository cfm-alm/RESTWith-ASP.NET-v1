﻿using RestwithASPNETUdemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestwithASPNETUdemy.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("codigo")]
        public long Id { get; set; }
        [JsonPropertyName("nome")]
        public string FirstName { get; set; }
        [JsonPropertyName("sobrenome")]
        public string LastName { get; set; }
        [JsonIgnore]
        public string Address { get; set; }
        [JsonPropertyName("sexo")]
        public string Gender { get; set; }
    }
}
