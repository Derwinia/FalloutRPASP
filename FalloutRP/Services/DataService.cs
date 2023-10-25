using FalloutRP.DTO;
using FalloutRPDAL.Entities;
using FalloutRPDAL;

namespace FalloutRP.Services
{
    public class DataService
    {
        private readonly FalloutRPContext _falloutRPContext;
        public DataService(FalloutRPContext falloutRPContext)
        {
            _falloutRPContext = falloutRPContext;
        }

        public void DataCreate(DataCreateDTO dataCreateDTO)
        {
            Data newData = new Data
            {
                Name = dataCreateDTO.Name,
                ShortDescription = dataCreateDTO.ShortDescription,
                Description = dataCreateDTO.Description,
                Categorie = dataCreateDTO.Categorie,

            };

            _falloutRPContext.Datas.Add(newData);
            _falloutRPContext.SaveChanges();
        }

        public IEnumerable<DataListDTO> DataListCategorie(int categorie)
        {
            List<DataListDTO> datas = new List<DataListDTO>();

            List<Data> dataList = _falloutRPContext.Datas
                .Where(d => d.Categorie == categorie)
                .ToList();

            foreach (Data data in dataList)
            {
                datas.Add(new DataListDTO()
                {
                    Id = data.Id,
                    Name = data.Name,
                    ShortDescription = data.ShortDescription,
                    Description = data.Description,
                });
            }

            return datas;
        }

        public void DataUpdate(DataUpdateDTO dataDTO)
        {
            Data? data = _falloutRPContext.Datas.FirstOrDefault(u => u.Id == dataDTO.Id);

            if (data == null)
            {
                throw new KeyNotFoundException("Cette data n'existe pas");
            }

            data.Name = dataDTO.Name;
            data.ShortDescription = dataDTO.ShortDescription;
            data.Description = dataDTO.Description;

            _falloutRPContext.Update(data);
            _falloutRPContext.SaveChanges();
        }

        public void DataDelete(int idToDelete)
        {
            Data? data = _falloutRPContext.Datas.FirstOrDefault(p => p.Id == idToDelete);

            if (data is null)
            {
                throw new KeyNotFoundException("La data n'a pas été trouvé");
            }

            _falloutRPContext.Datas.Remove(data);
            _falloutRPContext.SaveChanges();
        }
    }
}

