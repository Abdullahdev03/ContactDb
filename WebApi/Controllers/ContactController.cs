
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
  private ContactService  _contactService;
  public ContactController()
  {
    _contactService = new ContactService();
  }
  [HttpGet("GetContacts")]
  public List<ContactDto> GetContacts()
  {
    var contacts = _contactService.GetContacts();
    return contacts;
  }
  [HttpGet("ByName")]
  public List<ContactDto> GetContactByName(string name)
  {
    var contacts = _contactService.GetContactByName(name);
    return contacts;
  }

  
  [HttpPost("Add")]
  public bool Add(ContactDto contact)
  {
    return _contactService.AddContact(contact);
  }
  [HttpPut("Update")]
  public bool Update(ContactDto contact)
  {
    return _contactService.UpdateContact(contact);
  }
  [HttpDelete("Delete")]
  public bool DeleteBlog(int id)
  {
    return _contactService.DeleteContact(id);
  }
}