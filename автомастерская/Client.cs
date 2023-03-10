//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace автомастерская
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.orders = new HashSet<orders>();
        }
    
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSername { get; set; }
        public string ClientLastName { get; set; }
        public byte[] ClientPhoto { get; set; }
        public string ClientMail { get; set; }
        public string ClientTel{ get; set; }

        public Nullable<System.DateTime> ClientDateOfBirthday { get; set; }
        public Nullable<int> ClientMale { get; set; }

        public string FullName => ClientSername + " " + ClientName + "\n" + ClientLastName;
     
        public virtual Male Male { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders> orders { get; set; }
    }
}
