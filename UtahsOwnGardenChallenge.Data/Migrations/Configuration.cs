using GoogleMaps.LocationServices;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Data.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<DatabaseDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(DatabaseDbContext context)
		{

			context.GardenSizes.AddOrUpdate(m => m.Name, new[]{
				new GardenSize() { Name = "Extra Small - Patio / Balcony boxes and/or Planters", Ordinal = 1},
				new GardenSize() { Name = "Small - 200 Square Feet or Less", Ordinal = 2 },
				new GardenSize() { Name = "Medium - 201-500 Square Feet", Ordinal = 3 },
				new GardenSize() { Name = "Large - 501-1000 Square Feet", Ordinal = 4 },
				new GardenSize() { Name = "Extra Large (XL) - 1001-5000 Square Feet", Ordinal = 5 },
				new GardenSize() { Name = "2XL - 5001-10000 Square Feet", Ordinal = 6 },
				new GardenSize() { Name = "3XL - More than 10001 Square Feet", Ordinal = 7 }
			});


			context.GardenTypes.AddOrUpdate(m => m.Name, new[]
			                                             {
			                                             	new GardenType() {Name = "Personal", Ordinal = 1},
															new GardenType() {Name = "Community Garden Member", Ordinal = 2},
															new GardenType() {Name = "Community Garden less than 50 members", Ordinal = 3},
															new GardenType() {Name = "Community Garden 51-100 members", Ordinal = 4},
															new GardenType() {Name = "Community Garden 101-500 members", Ordinal = 5},
															new GardenType() {Name = "Community Garden 501-1000 members", Ordinal = 6},
															new GardenType() {Name = "Community Garden Over 1000 members", Ordinal = 7},
															new GardenType() {Name = "School Garden - Size 1A", Ordinal = 8},
															new GardenType() {Name = "School Garden - Size 2A", Ordinal = 9},
															new GardenType() {Name = "School Garden - Size 3A", Ordinal = 10},
															new GardenType() {Name = "School Garden - Size 4A", Ordinal = 11},
															new GardenType() {Name = "School Garden - Size 5A", Ordinal = 12},
															new GardenType() {Name = "Commercial", Ordinal = 13},
															new GardenType() {Name = "Community Supported Agriculture", Ordinal = 14},
															new GardenType() {Name = "Other", Ordinal = 15}
			                                             });

			context.PlantTypes.AddOrUpdate(m => m.Name, new[]
			                                            {
			                                            	new PlantType(){Name ="Fruits"},
 															new PlantType(){Name ="Houseplants"},
															new PlantType(){Name ="Natives"},
															new PlantType(){Name ="Ornamentals"},
															new PlantType(){Name ="Vegetables"}
			                                            });

			context.GardenReasons.AddOrUpdate(m => m.Name, new[]
			                                               {
			                                               	new GardenReason(){Name = "Beauty"},
															new GardenReason(){Name = "Charity"},
															new GardenReason(){Name = "Food"},
															new GardenReason(){Name = "Fun"},
															new GardenReason(){Name = "Nature"}
			                                               });

			SetupCounties(context);

			//UpdateLogitudeAndLatitude(context);
		}

		private void UpdateLogitudeAndLatitude(DatabaseDbContext context)
		{
			var googleLocationService = new GoogleLocationService();

			var cities = context.Cities.ToList();
			for (var i = 0; i < cities.Count(); i++)
			{
				var city = cities.ElementAt(i);
				if (city.Latitude == null || city.Latitude == null)
				{
					var mapPoint = googleLocationService.GetLatLongFromAddress(string.Format("{0}, Utah", city.Name));
					if (mapPoint != null)
					{
						city.Latitude = (float)mapPoint.Latitude;
						city.Longitude = (float)mapPoint.Longitude;
						context.Cities.Attach(city);
						context.SaveChanges();
					}
				}
			}
		}

		private void SetupCounties(DatabaseDbContext context)
		{
			var davis = new County()
						{
							Name = "Davis",
							Cities = new[]
			            	         {
			            	         	new City() {Name = "Bountiful"},
			            	         	new City() {Name = "Centerville"},
			            	         	new City() {Name = "Clearfield"},
			            	         	new City() {Name = "Clinton"},
			            	         	new City() {Name = "Farmington"},
			            	         	new City() {Name = "Fruit Heights"},
			            	         	new City() {Name = "Kaysville"},
			            	         	new City() {Name = "Layton"},
			            	         	new City() {Name = "N. Salt Lake"},
			            	         	new City() {Name = "S. Weber"},
			            	         	new City() {Name = "Sunset"},
			            	         	new City() {Name = "W. Bountiful"},
			            	         	new City() {Name = "West Point"},
			            	         	new City() {Name = "Woods Cross"}
			            	         }
						};

			context.Counties.AddOrUpdate(m => m.Name, davis);

			var beaver = new County()
						 {
							 Name = "Beaver",
							 Cities = new[]
			             	         {
			             	         	new City() {Name = "Beaver"},
			             	         	new City() {Name = "Frisco"},
			             	         	new City() {Name = "Greenville"},
			             	         	new City() {Name = "Milford"},
			             	         	new City() {Name = "Minersville"},
			             	         	new City() {Name = "Sulphurdale"}
			             	         }
						 };

			context.Counties.AddOrUpdate(m => m.Name, beaver);

			var boxElder = new County()
			{
				Name = "Box Elder",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Bear River City"},
			            	         	new City() {Name = "Brigham City"},
			            	         	new City() {Name = "Collinston"},
			            	         	new City() {Name = "Deweyville"},
			            	         	new City() {Name = "Fielding"},
			            	         	new City() {Name = "Garland"},
			            	         	new City() {Name = "Grouse Creek"},
			            	         	new City() {Name = "Honeyville"},
			            	         	new City() {Name = "Mantua"},
			            	         	new City() {Name = "Park Valley"},
			            	         	new City() {Name = "Plymouth"},
			            	         	new City() {Name = "Portage"},
			            	         	new City() {Name = "Riverside"},
			            	         	new City() {Name = "Snowville"},
										new City() {Name = "Tremonton"},
			            	         	new City() {Name = "Willard"},
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, boxElder);

			var cache = new County()
			{
				Name = "Cache",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Amalga"},
			            	         	new City() {Name = "Benson"},
			            	         	new City() {Name = "Clarkston"},
			            	         	new City() {Name = "College Young Ward"},
			            	         	new City() {Name = "Cornish"},
			            	         	new City() {Name = "Cove"},
			            	         	new City() {Name = "Hyde Park"},
			            	         	new City() {Name = "Hyrum"},
			            	         	new City() {Name = "Logan"},
			            	         	new City() {Name = "Millville"},
			            	         	new City() {Name = "Newton"},
			            	         	new City() {Name = "Nibley"},
			            	         	new City() {Name = "North Logan"},
			            	         	new City() {Name = "Paradise"},
										new City() {Name = "Providence"},
			            	         	new City() {Name = "Richmond"},
										new City() {Name = "River Heights"},
										new City() {Name = "Smithfield"},
										new City() {Name = "Trenton"},
										new City() {Name = "Wellsville"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, cache);

			var carbon = new County()
			{
				Name = "Carbon",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "East Carbon"},
			            	         	new City() {Name = "Helper"},
			            	         	new City() {Name = "Price"},
			            	         	new City() {Name = "Scofield Town"},
			            	         	new City() {Name = "Sunnyside"},
			            	         	new City() {Name = "Wellington"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, carbon);

			var daggett = new County()
			{
				Name = "Daggett",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Manila"},
			            	         	new City() {Name = "Dutch John"},
			            	         	new City() {Name = "Linwood"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, daggett);

			var duchesne = new County()
			{
				Name = "Duchesne",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Altamont"},
			            	         	new City() {Name = "Duchesne"},
			            	         	new City() {Name = "Myton"},
			            	         	new City() {Name = "Neola"},
			            	         	new City() {Name = "Roosevelt"},
			            	         	new City() {Name = "Tabiona"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, duchesne);

			var emery = new County()
			{
				Name = "Emery",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Castle Dale"},
			            	         	new City() {Name = "Clawson"},
			            	         	new City() {Name = "Cleveland"},
			            	         	new City() {Name = "Elmo"},
			            	         	new City() {Name = "Emery"},
			            	         	new City() {Name = "Ferron"},
										new City() {Name = "Green River"},
										new City() {Name = "Huntington"},
										new City() {Name = "Lawrence"},
										new City() {Name = "Moore"},
										new City() {Name = "Orangeville"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, emery);

			var garfield = new County()
			{
				Name = "Garfield",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Antimony"},
			            	         	new City() {Name = "Bryce"},
			            	         	new City() {Name = "Bryce Canyon City"},
			            	         	new City() {Name = "Boulder"},
			            	         	new City() {Name = "Cannonville"},
			            	         	new City() {Name = "Escalante"},
										new City() {Name = "Hatch"},
										new City() {Name = "Huntington"},
										new City() {Name = "Henrieville"},
										new City() {Name = "Panguitch"},
										new City() {Name = "Ticaboo"},
										new City() {Name = "Tropic"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, garfield);

			var grand = new County()
			{
				Name = "Grand",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Castle Valley"},
			            	         	new City() {Name = "Moab"},
			            	         	new City() {Name = "Brendel"},
			            	         	new City() {Name = "Thompson Springs"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, grand);

			var iron = new County()
			{
				Name = "Iron",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Parowan City"},
			            	         	new City() {Name = "Brianhead"},
			            	         	new City() {Name = "Cedar City"},
			            	         	new City() {Name = "Enoch"},
										new City() {Name = "Kanarraville"},
										new City() {Name = "Paragonah"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, iron);

			var juab = new County()
			{
				Name = "Juab",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Callao"},
			            	         	new City() {Name = "Eureka"},
			            	         	new City() {Name = "Levan"},
			            	         	new City() {Name = "Mona"},
										new City() {Name = "Nephi"},
										new City() {Name = "Rocky Ridge"},
										new City() {Name = "Trout Creek"},
										new City() {Name = "Partoun"},
										new City() {Name = "Mills"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, juab);

			var kane = new County()
			{
				Name = "Kane",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Kanab"},
			            	         	new City() {Name = "Alton"},
			            	         	new City() {Name = "Big Water"},
			            	         	new City() {Name = "Glendale"},
										new City() {Name = "Orderville"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, kane);

			var millard = new County()
			{
				Name = "Millard",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Border"},
			            	         	new City() {Name = "Deseret"},
			            	         	new City() {Name = "Delta"},
			            	         	new City() {Name = "EskDale"},
			            	         	new City() {Name = "Fillmore"},
			            	         	new City() {Name = "Gandy"},
										new City() {Name = "Garrison"},
										new City() {Name = "Hinckley"},
										new City() {Name = "Holden"},
										new City() {Name = "Kanosh"},
										new City() {Name = "Leamington"},
										new City() {Name = "Lynndyl"},
										new City() {Name = "Meadow"},
										new City() {Name = "Oak City"},
										new City() {Name = "Oasis"},
										new City() {Name = "Scipio"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, millard);

			var morgan = new County()
			{
				Name = "Morgan",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Croydon"},
			            	         	new City() {Name = "Monte Verde"},
			            	         	new City() {Name = "Morgan"},
			            	         	new City() {Name = "Mountain Green"},
			            	         	new City() {Name = "Peterson"},
			            	         	new City() {Name = "Porterville"},
										new City() {Name = "Richville"},
										new City() {Name = "Stoddard"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, morgan);

			var piute = new County()
			{
				Name = "Piute",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Circleville"},
			            	         	new City() {Name = "Greenwich"},
			            	         	new City() {Name = "Junction"},
			            	         	new City() {Name = "Kingston"},
			            	         	new City() {Name = "Marysvale"},
			            	         	new City() {Name = "Pittsburg"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, piute);

			var rich = new County()
			{
				Name = "Rich",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Garden"},
			            	         	new City() {Name = "Garden City"},
			            	         	new City() {Name = "Junction"},
			            	         	new City() {Name = "Laketown"},
			            	         	new City() {Name = "Randolph"},
			            	         	new City() {Name = "Woodruff"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, rich);

			var saltLake = new County()
			{
				Name = "Salt Lake",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Alta"},
			            	         	new City() {Name = "Bluffdale"},
			            	         	new City() {Name = "Cottonwood Heights"},
			            	         	new City() {Name = "Draper"},
			            	         	new City() {Name = "Fillmore"},
			            	         	new City() {Name = "Herriman"},
										new City() {Name = "Holladay"},
										new City() {Name = "Midvale"},
										new City() {Name = "Riverton"},
										new City() {Name = "Salt Lake City"},
										new City() {Name = "Sandy"},
										new City() {Name = "South Jordan"},
										new City() {Name = "South Salt Lake"},
										new City() {Name = "Taylorsville"},
										new City() {Name = "West Jordan"},
										new City() {Name = "West Valley City"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, saltLake);

			var sanJaun = new County()
			{
				Name = "San Juan",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Aneth"},
			            	         	new City() {Name = "Blanding"},
			            	         	new City() {Name = "Bluff"},
			            	         	new City() {Name = "Halchita"},
			            	         	new City() {Name = "Halls Crossing"},
			            	         	new City() {Name = "La Sal"},
										new City() {Name = "Mexican Hat"},
										new City() {Name = "Montezuma Creek"},
										new City() {Name = "Monticello"},
										new City() {Name = "Navajo Mountain"},
										new City() {Name = "Monument Valley"},
										new City() {Name = "Spanish Valley"},
										new City() {Name = "Tselakai Dezza"},
										new City() {Name = "White Mesa"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, sanJaun);

			var sanpete = new County()
			{
				Name = "Sanpete",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Ephraim"},
			            	         	new City() {Name = "Fairview"},
			            	         	new City() {Name = "Fountain Green"},
			            	         	new City() {Name = "Gunnison"},
			            	         	new City() {Name = "Manti"},
			            	         	new City() {Name = "Mayfield"},
										new City() {Name = "Moroni"},
										new City() {Name = "Mount Pleasant"},
										new City() {Name = "Spring City"},
										new City() {Name = "Sterling"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, sanpete);

			var sevier = new County()
			{
				Name = "Sevier",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Koosharem"},
			            	         	new City() {Name = "Richfield"},
			            	         	new City() {Name = "Salina"},
			            	         	new City() {Name = "Monroe"},
			            	         	new City() {Name = "Aurora"},
			            	         	new City() {Name = "Redmond"},
										new City() {Name = "Elsinore"},
										new City() {Name = "Annabella"},
										new City() {Name = "Glenwood"},
										new City() {Name = "Sigurd"},
										new City() {Name = "Joseph"},
										new City() {Name = "Central Valley"},
										new City() {Name = "Sevier"},
										new City() {Name = "Venice"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, sevier);

			var summit = new County()
			{
				Name = "Summit",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Coalville"},
			            	         	new City() {Name = "Kamas"},
			            	         	new City() {Name = "Oakley"},
			            	         	new City() {Name = "Park City"},
			            	         	new City() {Name = "Francis"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, summit);

			var tooele = new County()
			{
				Name = "Tooele",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Grantsville"},
			            	         	new City() {Name = "Ophir"},
			            	         	new City() {Name = "Rush Valley"},
			            	         	new City() {Name = "Stockton"},
			            	         	new City() {Name = "Tooele"},
										new City() {Name = "Vernon"},
										new City() {Name = "Wendover"}

			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, tooele);

			var uintah = new County()
			{
				Name = "Uintah",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Ballard"},
			            	         	new City() {Name = "Bonanza"},
			            	         	new City() {Name = "Fort Duchesne"},
			            	         	new City() {Name = "Jensen"},
			            	         	new City() {Name = "Lapoint"},
										new City() {Name = "Maeser"},
										new City() {Name = "Naples"},
										new City() {Name = "Randlett"},
										new City() {Name = "Tridell"},
										new City() {Name = "Vernal"},
										new City() {Name = "Whiterocks"}

			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, uintah);

			var utah = new County()
			{
				Name = "Utah",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Alpine"},
			            	         	new City() {Name = "American Fork"},
			            	         	new City() {Name = "Cedar Fort"},
			            	         	new City() {Name = "Cedar Hills"},
			            	         	new City() {Name = "Draper"},
										new City() {Name = "Eagle Mountain"},
										new City() {Name = "Elk Ridge"},
										new City() {Name = "Fairfield"},
										new City() {Name = "Genola"},
										new City() {Name = "Goshen"},
										new City() {Name = "Highland"},
										new City() {Name = "Lehi"},
										new City() {Name = "Lindon"},
										new City() {Name = "Mapleton"},
										new City() {Name = "Orem"},
										new City() {Name = "Payson"},
										new City() {Name = "Pleasant Grove"},
										new City() {Name = "Provo"},
										new City() {Name = "Salem"},
										new City() {Name = "Santaquin"},
										new City() {Name = "Saratoga Springs"},
										new City() {Name = "Spanish Fork"},
										new City() {Name = "Springville"},
										new City() {Name = "Vineyard"},
										new City() {Name = "Woodland Hills"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, utah);

			var wasatch = new County()
			{
				Name = "Wasatch",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Charleston"},
			            	         	new City() {Name = "Daniel"},
			            	         	new City() {Name = "Heber"},
			            	         	new City() {Name = "Hideout"},
			            	         	new City() {Name = "Timber Lakes"},
										new City() {Name = "Wallsburg"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, wasatch);

			var washington = new County()
			{
				Name = "Washington",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Apple Valley"},
			            	         	new City() {Name = "Enterprise"},
			            	         	new City() {Name = "Hildale"},
			            	         	new City() {Name = "Hurricane"},
			            	         	new City() {Name = "Ivins"},
										new City() {Name = "LaVerkin"},
										new City() {Name = "Leeds"},
										new City() {Name = "New Harmony"},
										new City() {Name = "Rockville"},
										new City() {Name = "Santa Clara"},
										new City() {Name = "Springdale"},
										new City() {Name = "St. George"},
										new City() {Name = "Toquerville"},
										new City() {Name = "Virgin"},
										new City() {Name = "Washington"}
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, washington);

			var wayne = new County()
			{
				Name = "Wayne",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Bicknell"},
										new City() {Name = "Caineville"},
										new City() {Name = "Fremont"},
										new City() {Name = "Grover"},
										new City() {Name = "Loa"},
										new City() {Name = "Lyman"},
										new City() {Name = "Teasdale"},
										new City() {Name = "Torrey"},
										new City() {Name = "Hanksville"},
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, wayne);

			var weber = new County()
			{
				Name = "Weber",
				Cities = new[]
			            	         {
			            	         	new City() {Name = "Farr West"},
										new City() {Name = "Harrisville"},
										new City() {Name = "Hooper"},
										new City() {Name = "Huntsville"},
										new City() {Name = "Marriott-Slaterville"},
										new City() {Name = "North Ogden"},
										new City() {Name = "Ogden"},
										new City() {Name = "Plain City"},
										new City() {Name = "Pleasant View"},
										new City() {Name = "Riverdale"},
										new City() {Name = "South Ogden"},
										new City() {Name = "Uintah"},
										new City() {Name = "Washington Terrace"},
										new City() {Name = "West Haven"},
										new City() {Name = "Roy"},
			            	         }
			};

			context.Counties.AddOrUpdate(m => m.Name, weber);
		}
	}
}
