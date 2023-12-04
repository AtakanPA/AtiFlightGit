using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtiFlight.Models
{
    public class AirPlane
    {
        [Key]
        public int AirPlaneID { get; set; }

        public List<Seat> Seats {  get; set; }
        public int? FlightID {  get; set; }
        public Flight? Flight { get; set; }
      
        public AirPlane()
        {
           
           
            
               
                InitializeSeats(); // StartingSeatID değeri set edildiğinde koltukları oluştur
           
        }
        private void InitializeSeats()
        {
            for (int i = 0; i < 40; i++)
            {
                Seat seat = new Seat();
                // Koltukla ilgili gerekli özelliklerin atanması
                seat.SeatID = AirPlaneID*40+i; // Koltuk numarasını ata (örneğin, 1'den 40'a kadar)

                // Diğer koltuk özelliklerini burada atayabilirsiniz

                Seats.Add(seat); // Oluşturulan koltuğu listeye ekle
            }
        }
    }
}
