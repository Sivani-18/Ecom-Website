using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnetapp.DTOs
{


public class LoginRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

}