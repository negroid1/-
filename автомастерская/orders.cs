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
    
    public partial class orders
    {
        public int order_id { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public Nullable<int> staff_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> client_id { get; set; }
        public Nullable<int> service_id { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual products products { get; set; }
        public virtual services services { get; set; }
        public virtual staffes staffes { get; set; }
    }
}
