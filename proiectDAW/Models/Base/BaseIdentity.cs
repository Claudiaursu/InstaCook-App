using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.Base{
    public class BaseEntity : IBaseEntity
    {

        [Key]
        // Generates a value when a row is inserted
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        // Generates a value when a row is inserted or updated
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        // Does not generate a value
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? DateCreated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateModified { get; set; }
    }
}
