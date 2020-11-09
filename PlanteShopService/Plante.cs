using System;
using System.ComponentModel.DataAnnotations;

namespace PlanteShopService
{
    public class Plante
    {
        [Key]
        public int PlanteId { get; set; }

        public string PlanteType { get; set; }
        public string PlanteNavn { get; set; }
        public double Price { get; set; }
        public int MaksHoejde { get; set; }

        public Plante()
        {
            
        }

        public Plante(int planteId, string planteType, string planteNavn, double price, int maksHoejde)
        {
            PlanteId = planteId;
            PlanteType = planteType;
            PlanteNavn = planteNavn;
            Price = price;
            MaksHoejde = maksHoejde;
        }

        public override string ToString()
        {
            return $"{nameof(PlanteId)}: {PlanteId}, {nameof(PlanteType)}: {PlanteType}, {nameof(PlanteNavn)}: {PlanteNavn}, {nameof(Price)}: {Price}, {nameof(MaksHoejde)}: {MaksHoejde}";
        }
    }
}
