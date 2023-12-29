using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

public class Customer
{
    [Key]
    public int CustomerNumber { get; set; }
    public string? ServiceType { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime ServingTime { get; set; }
    public string? Teller { get; set; }

    [ForeignKey("ServicePointId")]
    public int? ServicePointId { get; set; }
    public ServicePoint? ServicePoint { get; set; }

    public CustomerStatus Status { get; set; }
}
public enum CustomerStatus
{
    InQueue,
    Serving,
    NoShow,
    Finished,
    Transferred,
}

