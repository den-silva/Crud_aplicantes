using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Cliente
    /// </summary>
    public class AplicanteModel
    {
        public int Id { get; set; }     

        /// <summary>
        /// Cidade
        /// </summary>
        [Required]
        public string NomeCidade { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Nota { get; set; }

    }
}