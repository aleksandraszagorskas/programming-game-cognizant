using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingGame.App.Models
{
    public class Entry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntryId { get; set; }
        public string ParticipantName { get; set; }
        public Task Task { get; set; }
        public string SolutionCode { get; set; }
        public string Time { get; set; }
        public bool IsSolved { get; set; }
    }
}
