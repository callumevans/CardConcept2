using Microsoft.AspNetCore.Mvc;
using WebApplication5.Cards;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/cards")]
    public class CardsController : Controller
    {
        private readonly CardBuilderService cardBuilderService;

        public CardsController(CardBuilderService cardBuilderService)
        {
            this.cardBuilderService = cardBuilderService;
        }

        [HttpPost]
        public IActionResult Post()
        {
            Card card = cardBuilderService.GenerateCard(Faction.Good);
            return Ok(card);
        }
    }
}