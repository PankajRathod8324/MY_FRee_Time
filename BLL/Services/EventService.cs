using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Entities.ViewModel;
using X.PagedList.Extensions;
using X.PagedList;
using System.Linq;
using BLL.Interfaces;

namespace BLL.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventrepository;



    public EventService(IEventRepository eventrepository)
    {
        _eventrepository = eventrepository;
    }

    public bool Checkavailability(Event eventEntity)
    {
        var events = _eventrepository.GetAllEvents().Where(e => e.EventDate == eventEntity.EventDate &&  e.EventStatus == "Pending" && e.IsDeleted==false).ToList();
        foreach (var e in events)
        {
            if (e.EventDate == eventEntity.EventDate)
            {
                if (e.EventStartTime < eventEntity.EventEndTime && e.EventEndTime > eventEntity.EventStartTime)
                {
                    return false; // Overlap found
                }
                
            }
        }
        return true; // No overlap found
    }
    

}