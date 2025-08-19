using System.Text.Json.Serialization;

namespace AccontApi.Core.Entities
{
    public class Parameters
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Length_x")]
        public decimal LengthX { get; set; }

        [JsonPropertyName("Width_y")]
        public decimal WidthY { get; set; }

        [JsonPropertyName("Height_z")]
        public decimal HeightZ { get; set; }

        [JsonPropertyName("Weight_Tonns")]
        public decimal WeightTonns { get; set; }
        private decimal _COGx;
       // [JsonPropertyName("COG_x")]
        public decimal COGx {
            get => _COGx;
            set
            {
                if (value != null && decimal.TryParse(value.ToString(), out var result))
                {
                    _COGx = result;
                }
                else
                {
                    _COGx = 0; // Or handle as needed (e.g. throw exception, log warning, etc.)
                }
            }
        }


        [JsonPropertyName("COG_y")]
        public decimal COGy { get; set; }

        [JsonPropertyName("COG_z")]
        public decimal COGz { get; set; }

        [JsonPropertyName("Area")]
        public decimal Area { get; set; }

        [JsonPropertyName("MOI_x_LocalCentroid")]
        public decimal MOIxLocalCentroid { get; set; }

        [JsonPropertyName("MOI_y_LocalCentroid")]
        public decimal MOIyLocalCentroid { get; set; }

        [JsonPropertyName("MOI_z_LocalCentroid")]
        public decimal MOIzLocalCentroid { get; set; }

        [JsonPropertyName("UnitBuoyancy_TonnsPerM2")]
        public decimal UnitBuoyancyTonnsPerM2 { get; set; }

        [JsonPropertyName("MinimumFreeboard")]
        public decimal MinimumFreeboard { get; set; }

        [JsonPropertyName("MaximumDraft")]
        public decimal MaximumDraft { get; set; }

        [JsonPropertyName("FloatCategoryId")]
        public int FloatCategoryId { get; set; }
    }
}
