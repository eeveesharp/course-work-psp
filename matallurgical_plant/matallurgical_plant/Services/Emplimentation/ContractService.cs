using ClosedXML.Excel;
using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace matallurgical_plant.Services.Emplimentation
{
    public class ContractService : IContractService
    {
        private readonly AppDbContext _db;

        public ContractService(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Contract contract = _db.Contracts.Where(contract => contract.Id == id).FirstOrDefault();
            _db.Contracts.Remove(contract);
            _db.SaveChanges();
        }

        public void Edit(int id, Contract item)
        {
            _db.Contracts.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Contract> GetAll()
        {
            return _db.Contracts
                .Include(x=>x.User)
                .Include(x=>x.Specification)
                .Include(x=>x.Specification.Product)
                .AsNoTracking()
                .ToList();
        }

        public Contract GetById(int id)
        {
            return _db.Contracts.Where(contract => contract.Id == id).Include(x => x.Specification).Include(x => x.User).FirstOrDefault();
        }

        public void Create(Contract item)
        {
            _db.Contracts.Add(item);
            _db.SaveChanges();
        }

        public XLWorkbook GenerateExcelReport()
        {
            var orders = GetAll();

            var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Отчет");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "Имя заказчика";
            worksheet.Cell(currentRow, 2).Value = "Фамилия заказчика";
            worksheet.Cell(currentRow, 3).Value = "Отчество заказчика";
            worksheet.Cell(currentRow, 4).Value = "Продутк";
            worksheet.Cell(currentRow, 5).Value = "Материал";
            worksheet.Cell(currentRow, 6).Value = "Дата";
            worksheet.Cell(currentRow, 7).Value = "Цена";
            worksheet.Cell(currentRow, 8).Value = "Количество";
            worksheet.Cell(currentRow, 9).Value = "Поставщик";

            foreach (var order in orders)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = order?.User?.FirstName ?? "нет данных";
                worksheet.Cell(currentRow, 2).Value = order?.User?.SecondName ?? "нет данных";
                worksheet.Cell(currentRow, 3).Value = order?.User?.ThirdName ?? "нет данных";
                worksheet.Cell(currentRow, 4).Value = order?.Specification?.Product?.NameProduct ?? "нет данных";
                worksheet.Cell(currentRow, 5).Value = order?.Specification?.Product?.Material ?? "нет данных";
                worksheet.Cell(currentRow, 6).Value = order?.Specification?.DeliveryTime;
                worksheet.Cell(currentRow, 7).Value = order?.FinalPrice ?? "нет данных";
                worksheet.Cell(currentRow, 8).Value = order.Quantity;
                worksheet.Cell(currentRow, 9).Value = "ОАО Метталлинтертейнинг";
            }

            return workbook;
        }
    }
}
