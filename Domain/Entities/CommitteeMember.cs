using Domain.Base;
using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{

    [Table("comittee_members")]
    public class CommitteeMember : Entity<int>
    {


        public CommitteeMember()
        {

        }

        [Column("full_name")]
        [MaxLength(50)]
        [MinLength(3)]
        [Required]
        public string FullName { set; get; } = string.Empty;

        [Column("email")]
        [MaxLength(50)]
        [MinLength(3)]
        [Required]
        [EmailAddress]
        public string Email { set; get; } = string.Empty;

        [Column("phone")]
        [MaxLength(10)]
        [MinLength(5)]
        [Required]
        [Phone]
        public string Phone { set; get; } = string.Empty;

        [Column("password")]
        [MaxLength(15)]
        [MinLength(1)]
        [Required]

        public string Password { set; get; } = string.Empty;


        [Column("identification")]
        [MaxLength(15)]
        [MinLength(1)]
        [Required]

        public string Identification { set; get; } = string.Empty;

        public EnumStatusRegisterCommitteMember IsValid()
        {


            if (FullName == string.Empty ||
               FullName.IsData() != TypeData.Name ||
               Email == string.Empty ||
               Email.IsData() != TypeData.Email ||
               Phone == string.Empty ||
               Phone.IsData() != TypeData.Phone ||
               Password == string.Empty ||
               Identification.IsData() != TypeData.Document)
            {
                return EnumStatusRegisterCommitteMember.SomeIsEmpty;
            }
            return EnumStatusRegisterCommitteMember.Success;
        }

        public EnumStatusRegisterCommitteMember Valid(EnumStatusRegisterCommitteMember status)
        {
            return status;
        }

        public static CommitteeMember Build(string fullName, string email, string phone, string password, string identification)
        {
            return new CommitteeMember
            {
                Phone = phone,
                Email = email,
                FullName = fullName,
                Password = password,
                Identification = identification

            };
        }


    }
}
