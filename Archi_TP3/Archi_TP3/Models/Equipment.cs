using System;

namespace Archi_TP3.Models
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public String EquipmentLabel { get; set; }
        public int EquipmentPrice { get; set; }
        public int RoomID { get; set; }

        public Room Room { get; set; }
    }
}