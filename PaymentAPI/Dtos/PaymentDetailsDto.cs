﻿using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Dtos
{
    public class PaymentDetailsDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        [Required]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be 16 digits.")]
        public string CardOwnerNumber { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Security code must be 3 digits.")]
        public string SecurityCode { get; set; }
    }
}