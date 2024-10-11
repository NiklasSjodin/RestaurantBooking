using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.Table;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        public TableService(ITableRepository tableRepo)
        {
            _tableRepository = tableRepo;
        }

        public async Task<IEnumerable<GetTableDTO>> GetAllTablesAsync()
        {
            var tables = await _tableRepository.GetAllTablesAsync();
            var tablesList = tables.Select(t => new GetTableDTO
            {
                TableID = t.TableID,
                TableNumber = t.TableNumber,
                NumberOfSeats = t.NumberOfSeats,
            }).ToList();

            return tablesList;
        }

        public async Task<IEnumerable<GetTableDTO>> GetAvailableTablesAsync(DateTime reservationDate, int numberOfGuests)
        {
            var availableTables = await _tableRepository.GetAvailableTablesAsync(reservationDate, numberOfGuests);

            if (reservationDate.Date < DateTime.UtcNow.Date)
            {
                throw new ArgumentException("You cannot book a table for a date in the past.");
            }

            // Kontrollera att tiden är inom bokningsbara tiderna (17:00 till 23:00 nästa dag)
            var restaurantCloseTime = new TimeSpan(23, 0, 0);
            var restaurantOpenTime = new TimeSpan(17, 0, 0);

            if (reservationDate.TimeOfDay < restaurantOpenTime ||
                (reservationDate.TimeOfDay > restaurantCloseTime))
            {
                throw new ArgumentException("The restaurant is open between 17:00 and 23:00.");
            }

            var tablesList = availableTables.Select(t => new GetTableDTO
            {
                TableID = t.TableID,
                TableNumber = t.TableNumber,
                NumberOfSeats = t.NumberOfSeats
            }).ToList();

            return tablesList;
        }

        public async Task<GetTableDTO> GetTableByIdAsync(int id)
        {
            var foundTable = await _tableRepository.GetTableByIdAsync(id);

            if(foundTable != null)
            {
                var table = new GetTableDTO
                {
                    TableID = foundTable.TableID,
                    TableNumber = foundTable.TableNumber,
                    NumberOfSeats = foundTable.NumberOfSeats,
                };
                return table;
            }
            else
            {
                throw new KeyNotFoundException($"Table with ID {id} not found!");
            }
        }
        public async Task AddTableAsync(CreateTableDTO createTable)
        {
            var newTable = new Table
            {
                TableNumber = createTable.TableNumber,
                NumberOfSeats = createTable.NumberOfSeats,
            };
            await _tableRepository.AddTableAsync(newTable);
        }

        public async Task DeleteTableAsync(int id)
        {
            var tableFound = await _tableRepository.GetTableByIdAsync(id);
            await _tableRepository.DeleteTableAsync(tableFound);
        }

        public async Task UpdateTableAsync(UpdateTableDTO updateTable)
        {
            var table = await _tableRepository.GetTableByIdAsync(updateTable.TableID);

            if(table != null)
            {
                table.TableNumber = updateTable.TableNumber;
                table.NumberOfSeats = updateTable.NumberOfSeats;

                await _tableRepository.UpdateTableAsync(table);
            }
            else
            {
                throw new KeyNotFoundException($"Table not found!");
            }
        }
    }
}
