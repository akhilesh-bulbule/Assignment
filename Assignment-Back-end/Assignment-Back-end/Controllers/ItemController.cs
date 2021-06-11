using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_Back_end.Models;
using Abp.UI;
using Assignment_Back_end.Constants.ExceptionConstants;

namespace Assignment_Back_end.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ItemController : ControllerBase
   {
      private readonly ItemContext _dbContext;

      public ItemController(ItemContext dbContext)
      {
         _dbContext = dbContext;
      }


      //API call for fetching the list of Items from the database
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Item>>> GetItems()
      {
         try
         {
            var itemList = await _dbContext.Items.ToListAsync();
            return itemList;
         }
         catch (Exception)
         {
            throw new UserFriendlyException(ExceptionConst.ItemListNotFoundError);
         }
      }


      //API call for fetching a specific item by providing id to the database 
      [HttpGet("{id}")]
      public async Task<ActionResult<Item>> GetItem(int id)
      {
         try
         {
            var item = await _dbContext.Items.FindAsync(id);

            if (item == null)
            {
               throw new UserFriendlyException(ExceptionConst.ItemNotFoundError);
            }

            return item;
         }
         catch (Exception)
         {
            throw new UserFriendlyException(ExceptionConst.ItemNotFoundError);
         }

      }

      // API call for updating an item into a database
      [HttpPut("{id}")]
      public async Task<ActionResult<bool>> PutItem(int id, Item item)
      {
         try
         {
            if (id != item.ItemId)
            {
               throw new UserFriendlyException(ExceptionConst.ItemNotFoundError);
            }

            _dbContext.Entry(item).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return true;
         }
         catch (Exception)
         {
            return false;
            throw new UserFriendlyException(ExceptionConst.ItemNotFoundError);
         }
      }

      //API call for adding a new item into a database
      [HttpPost]
      public async Task<ActionResult<bool>> PostItem(Item item)
      {
         try
         {
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();

            return true;
            //return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
         }
         catch (Exception ex)
         {
            throw new UserFriendlyException(ExceptionConst.AddItemError);
         }

      }

      // API call for deleting an existing Item from the database.
      [HttpDelete("{id}")]
      public async Task<ActionResult<bool>> DeleteItem(int id)
      {
         try
         {
            var item = await _dbContext.Items.FindAsync(id);
            if (item == null)
            {
               throw new UserFriendlyException(ExceptionConst.ItemNotFoundError);
            }

            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();

            return true;
         }
         catch (Exception)
         {
            throw new UserFriendlyException(ExceptionConst.DeleteItemError);
         }
      }
   }
}
