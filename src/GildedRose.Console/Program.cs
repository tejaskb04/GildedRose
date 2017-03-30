using System.Collections.Generic;

namespace GildedRose.Console
{
	public class Program
	{
		IList<Item> Items;
		static void Main(string[] args)
		{
			System.Console.WriteLine("OMGHAI!");

			var app = new Program()
			{
				Items = new List<Item>
										  {
											  new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
											  new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
											  new Item {Name = "Elixir of the Mongoose", SellIn = 0, Quality = 70},
											  new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
											  new Item
												  {
													  Name = "Backstage passes to a TAFKAL80ETC concert",
													  SellIn = 6,
													  Quality = 48
												  },
											  new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
										  }

			};
			for (int i = 0; i < 3; i++)
			{
				app.updateQuality2();
				System.Console.WriteLine();
			}


			System.Console.ReadKey();
			System.Console.ReadLine();

		}
		public void updateQuality2()
		{
			for (var i = 0; i < Items.Count; i++)
			{
				System.Console.WriteLine(Items[i].Quality + " " + Items[i].SellIn);
				if (Items[i].Name == "Aged Brie" || Items[i].Name == "Backstage passes to a TAFKAL80ETC concert" && Items[i].Quality >= 0)
				{
					if (Items[i].SellIn < 11 && Items[i].SellIn > 5)
					{

						if (Items[i].Quality <= 48) { Items[i].Quality += 2; }
						Items[i].SellIn--;
					}
					else if (Items[i].SellIn <= 5 && Items[i].SellIn > 0)
					{
						if (Items[i].Quality <= 47) { Items[i].Quality += 3; }
						Items[i].SellIn--;
					}
					else if (Items[i].SellIn <= 0)
					{
						Items[i].Quality = 0;
					}
					else
					{
						Items[i].SellIn--;
					}
				}
				else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
				{
					// Do Nothing
				}
				else if (Items[i].Name == "Conjured Mana Cake" && Items[i].Quality > 1 && Items[i].SellIn > 0)
				{
					if (Items[i].Quality > 50)
					{
						Items[i].Quality = 50; // More Than 50 Quality Forbidden
					}
					else
					{
						Items[i].Quality -= 2; // Double Quality Degredation Rate
					}
					Items[i].SellIn--; // Setting Quality To 50 Is Counted As One SellIn
				}
				else
				{
					if (Items[i].Quality > 50)
					{
						Items[i].Quality = 50;
						if (Items[i].SellIn > 0)
						{
							Items[i].SellIn--;
						}
					}
					else
					{
						if (Items[i].Quality > 0 && Items[i].SellIn > 0)
						{
							Items[i].Quality--;
							Items[i].SellIn--;
						}
					}
				}
			}
		}

		public void UpdateQuality()
		{
			for (var i = 0; i < Items.Count; i++)
			{
				if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
				{
					if (Items[i].Quality > 0)
					{
						if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
						{
							Items[i].Quality = Items[i].Quality - 1;
						}
					}
				}
				else
				{
					if (Items[i].Quality < 50)
					{
						Items[i].Quality = Items[i].Quality + 1;

						if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
						{
							if (Items[i].SellIn < 11)
							{
								if (Items[i].Quality < 50)
								{
									Items[i].Quality = Items[i].Quality + 1;
								}
							}

							if (Items[i].SellIn < 6)
							{
								if (Items[i].Quality < 50)
								{
									Items[i].Quality = Items[i].Quality + 1;
								}
							}
						}
					}
				}

				if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
				{
					Items[i].SellIn = Items[i].SellIn - 1;
				}

				if (Items[i].SellIn < 0)
				{
					if (Items[i].Name != "Aged Brie")
					{
						if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
						{
							if (Items[i].Quality > 0)
							{
								if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
								{
									Items[i].Quality = Items[i].Quality - 1;
								}
							}
						}
						else
						{
							Items[i].Quality = Items[i].Quality - Items[i].Quality;
						}
					}
					else
					{
						if (Items[i].Quality < 50)
						{
							Items[i].Quality = Items[i].Quality + 1;
						}
					}
				}
			}
		}

	}

	public class Item
	{
		public string Name { get; set; }

		public int SellIn { get; set; }

		public int Quality { get; set; }
	}

}
