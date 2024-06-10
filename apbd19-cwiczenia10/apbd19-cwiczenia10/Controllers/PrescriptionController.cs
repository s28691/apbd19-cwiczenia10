using System.Net.Mail;
using System.Transactions;
using apbd19_cwiczenia10.Context;
using apbd19_cwiczenia10.DTOs;
using apbd19_cwiczenia10.Models;
using apbd19_cwiczenia10.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd19_cwiczenia10.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly DbService _dbService;

    public PrescriptionController(DbService dbService)
    {
        _dbService = dbService;
    }
    [HttpPost]
    public async Task<IActionResult> addPrescription([FromBody] PrescriptionRequest request)
    {
        if (request.Medicaments.Count > 10)
        {
            return BadRequest("Can't add more than 10 medicaments on one prescription");
        }
        if (!(request.DueDate > request.Date))
        {
            return BadRequest("Invalid prescription!");
        }
        foreach (var med in request.Medicaments)
        {
            if (!await _dbService.DoesMedicamentExist(med.IdMedicament))
            {
                return BadRequest($"Medicament {med.Name} not found");
            }
        }

        Patient newPatient = null;
        if (! await _dbService.DoesPatientExist(request.IdPatient))
        {
             newPatient = new Patient()
            {
                IdPatient = request.IdPatient,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthdate = request.Birthdate
            };
        }

        Prescription prescription = new Prescription()
        {
            Date = request.Date,
            DueDate = request.DueDate,
            IdDoctor = request.IdDoctor,
            IdPatient = request.IdPatient,
        };
        var prescriptions = new List<Prescription_Medicament>();
        foreach (var Med in request.Medicaments)
        {
            prescriptions.Add(new Prescription_Medicament()
            {
                IdMedicament = Med.IdMedicament,
                Dose = Med.Dose,
                Details = Med.Details,
            });
        }

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            if (newPatient != null)
            {
                await _dbService.AddNewPatient(newPatient);
            }
            await _dbService.AddNewPrescription(prescription);
            await _dbService.AddPrescriptionMedicaments(prescriptions);



        }
        return Ok();
    }
}