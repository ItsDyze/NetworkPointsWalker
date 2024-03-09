using Microsoft.EntityFrameworkCore;

namespace NetworkPointsWalker.Server.Entities
{
    public class AppDbContext:DbContext
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<OCP> OCPs { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Line> Lines { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OCP>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Track>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            var Seed = SeedData();

            modelBuilder.Entity<Station>().HasData(Seed.GetValueOrDefault(typeof(Station)));
            modelBuilder.Entity<OCP>().HasData(Seed.GetValueOrDefault(typeof(OCP)));
            modelBuilder.Entity<Track>().HasData(Seed.GetValueOrDefault(typeof(Track)));
        }

        private Dictionary<Type, object[]> SeedData()
        {
            OCP[] OCPs = [
                new OCP() { Id = Guid.NewGuid(), GPS = "5,952, 49,498", Name = "Réseau tertiaire-Site Belval" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,515, 5,9259", Name = "Belvaux-Soleuvre" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5161, 6,1011", Name = "Bettembourg-Voyageurs" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5224, 5,8916", Name = "Differdange(gare)" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4726, 6,0794", Name = "Dudelange-Usines" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5372, 5,8944", Name = "Niederkorn" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5541, 5,8786", Name = "Pétange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6663, 6,303", Name = "Roodt" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,8291, 6,095", Name = "Schieren" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4567, 6,079", Name = "Volmerange-les-Mines" },
                new OCP() { Id = Guid.NewGuid(), GPS = "50,0351, 6,01155", Name = "Mecher" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6619, 6,1363", Name = "Walferdange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5029, 5,9239", Name = "Belval-Rédange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5575, 6,1547", Name = "Berchem Est" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,8149, 6,10179", Name = "Colmar-Berg" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4788, 6,0822", Name = "Dudelange-Centre" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6439, 5,91741", Name = "Kleinbettingen" },
                new OCP() { Id = Guid.NewGuid(), GPS = "50,0941, 6,0258", Name = "Maulusmuhle" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,8294, 6,0949", Name = "Schieren Ligne 2" },
                new OCP() { Id = Guid.NewGuid(), GPS = "50,1192, 5,9909", Name = "Troisvierges" },
                new OCP() { Id = Guid.NewGuid(), GPS = "50,0613, 6,0247", Name = "Clervaux" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5506, 5,8372", Name = "Déviation vers 6h" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,9654, 5,95299", Name = "Paradiso" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,9666, 5,9283", Name = "Wiltz" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5525, 6,1418", Name = "Berchem Nord" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6152, 6,16667", Name = "Cents-Hamm" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5585, 6,1445", Name = "Fentange Sud(ligne 6)" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,7063, 6,4233", Name = "Manternach" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6025, 6,258", Name = "Oetrange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,551, 5,8433", Name = "Rodange(secteur)" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,599, 6,21267", Name = "Sandweiler-Contern" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4774, 6,0348", Name = "Tétange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4925, 6,0862", Name = "Dudelange-Burange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,508, 6,0508", Name = "Noertzange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5063, 6,0094", Name = "Schifflange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4998, 5,9458", Name = "Belval-Université" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4958, 5,9586", Name = "Belval-Usines" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,7961, 6,1197", Name = "Cruchten" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6752, 6,1391", Name = "Heisdorf" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,7516, 6,1102", Name = "Mersch" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6183, 6,0297", Name = "Mamer-Lycée" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6338, 6,1363", Name = "Dommeldange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5725, 5,9951", Name = "Dippach-Reckange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4938, 5,9855", Name = "Esch-sur-Alzette" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,9211, 6,053", Name = "Goebelsmuhle" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,9486, 6,0222", Name = "Kautenbach" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5997, 6,1347", Name = "Luxembourg" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5869, 6,0581", Name = "Leudelange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5956, 6,1206", Name = "Luxembourg secteur Hollerich" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,7211, 6,1227", Name = "Lintgen" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6985, 6,14022", Name = "Lorentzweiler" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4727, 6,07943", Name = "Luxembourg-Sud" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5734, 5,9598", Name = "Schouweiler" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6888, 6,3486", Name = "Betzdorf" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4834, 6,083", Name = "Dudelange-Ville" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5607, 6,1457", Name = "Fentange Sud(ligne 4)" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5015, 5,934", Name = "Belval-Lycée" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4938, 6,1088", Name = "Bettembourg-Marchandises" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,501, 6,03863", Name = "Brucherberg" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6125, 6,0608", Name = "Bertrange-Strassen" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5898, 6,1341", Name = "Luxembourg-Triage" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5697, 6,2208", Name = "Syren" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,7127, 6,4991", Name = "Wasserbillig" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,8647, 6,1536", Name = "Diekirch" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,8764, 6,1054", Name = "Burden" },
                new OCP() { Id = Guid.NewGuid(), GPS = "50,0168, 6,00721", Name = "Drauffelt" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,7031, 6,47996", Name = "Mertert" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5425, 6,1336", Name = "Berchem" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5301, 6,118", Name = "Livange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5533, 5,8608", Name = "Lamadelaine" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6383, 5,9822", Name = "Capellen" },
                new OCP() { Id = Guid.NewGuid(), GPS = "5,832, 49,551", Name = "Réseau tertiaire-Rodange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,619, 6,133", Name = "Pfaffenthal-Kirchberg" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,8966, 6,0919", Name = "Michelau" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5655, 6,1455", Name = "Fentange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5803, 6,1323", Name = "Howald" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5105, 6,0311", Name = "Scheuerbusch" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,46, 6,0325", Name = "Rumelange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,9883, 6,0002", Name = "Wilwerwiltz" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,7884, 6,06931", Name = "Bissen" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,8078, 6,0926", Name = "Colmar-Usines" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4656, 6,0101", Name = "Langengrund" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6255, 6,02", Name = "Mamer" },
                new OCP() { Id = Guid.NewGuid(), GPS = "5,8963, 49,5347", Name = "Réseau tertiaire-Site Differdange" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4857, 6,0352", Name = "Kayl" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,9566, 5,9816", Name = "Merkholtz" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5224, 5,89157", Name = "Differdange(PA)" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5104, 5,89133", Name = "Oberkorn" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6305, 6,2683", Name = "Munsbach" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6256, 6,02", Name = "Merkholtz Poste de block" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4783, 5,9582", Name = "Audun-le-Tiche" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5585, 5,92509", Name = "Bascharage-Sanem" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,7, 6,3863", Name = "Wecker" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,8472, 6,1066", Name = "Ettelbruck" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,7138, 6,5066", Name = "Wasserbillig frontière" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5518, 5,8106", Name = "Rodange frontière B A" },
                new OCP() { Id = Guid.NewGuid(), GPS = "50,173, 5,9653", Name = "Troisvierges frontière" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5518, 5,825", Name = "Rodange frontière B Aub" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4859, 5,9688", Name = "Esch-frontière" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,6437, 5,9042", Name = "Kleinbettingen frontière" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,4721, 6,10784", Name = "Bettembourg frontière" },
                new OCP() { Id = Guid.NewGuid(), GPS = "49,5433, 5,8106", Name = "Rodange frontière francaise" },
            ];

            List<Station> rawStations = new List<Station>(){
                new Station() { Id = Guid.NewGuid(), Name = "Belvaux-Soleuvre" },
                new Station() { Id = Guid.NewGuid(), Name = "Bettembourg-Voyageurs" },
                new Station() { Id = Guid.NewGuid(), Name = "Differdange(gare)" },
                new Station() { Id = Guid.NewGuid(), Name = "Dudelange-Usines" },
                new Station() { Id = Guid.NewGuid(), Name = "Niederkorn" },
                new Station() { Id = Guid.NewGuid(), Name = "Pétange" },
                new Station() { Id = Guid.NewGuid(), Name = "Roodt" },
                new Station() { Id = Guid.NewGuid(), Name = "Schieren" },
                new Station() { Id = Guid.NewGuid(), Name = "Volmerange-les-Mines" },
                new Station() { Id = Guid.NewGuid(), Name = "Walferdange" },
                new Station() { Id = Guid.NewGuid(), Name = "Belval-Rédange" },
                new Station() { Id = Guid.NewGuid(), Name = "Colmar-Berg" },
                new Station() { Id = Guid.NewGuid(), Name = "Dudelange-Centre" },
                new Station() { Id = Guid.NewGuid(), Name = "Kleinbettingen" },
                new Station() { Id = Guid.NewGuid(), Name = "Maulusmuhle" },
                new Station() { Id = Guid.NewGuid(), Name = "Troisvierges" },
                new Station() { Id = Guid.NewGuid(), Name = "Clervaux" },
                new Station() { Id = Guid.NewGuid(), Name = "Paradiso" },
                new Station() { Id = Guid.NewGuid(), Name = "Wiltz" },
                new Station() { Id = Guid.NewGuid(), Name = "Cents-Hamm" },
                new Station() { Id = Guid.NewGuid(), Name = "Fentange Sud(ligne 6)" },
                new Station() { Id = Guid.NewGuid(), Name = "Manternach" },
                new Station() { Id = Guid.NewGuid(), Name = "Oetrange" },
                new Station() { Id = Guid.NewGuid(), Name = "Rodange(secteur)" },
                new Station() { Id = Guid.NewGuid(), Name = "Sandweiler-Contern" },
                new Station() { Id = Guid.NewGuid(), Name = "Tétange" },
                new Station() { Id = Guid.NewGuid(), Name = "Dudelange-Burange" },
                new Station() { Id = Guid.NewGuid(), Name = "Noertzange" },
                new Station() { Id = Guid.NewGuid(), Name = "Schifflange" },
                new Station() { Id = Guid.NewGuid(), Name = "Belval-Université" },
                new Station() { Id = Guid.NewGuid(), Name = "Cruchten" },
                new Station() { Id = Guid.NewGuid(), Name = "Heisdorf" },
                new Station() { Id = Guid.NewGuid(), Name = "Mersch" },
                new Station() { Id = Guid.NewGuid(), Name = "Mamer-Lycée" },
                new Station() { Id = Guid.NewGuid(), Name = "Dommeldange" },
                new Station() { Id = Guid.NewGuid(), Name = "Dippach-Reckange" },
                new Station() { Id = Guid.NewGuid(), Name = "Esch-sur-Alzette" },
                new Station() { Id = Guid.NewGuid(), Name = "Goebelsmuhle" },
                new Station() { Id = Guid.NewGuid(), Name = "Kautenbach" },
                new Station() { Id = Guid.NewGuid(), Name = "Luxembourg" },
                new Station() { Id = Guid.NewGuid(), Name = "Leudelange" },
                new Station() { Id = Guid.NewGuid(), Name = "Luxembourg secteur Hollerich" },
                new Station() { Id = Guid.NewGuid(), Name = "Lintgen" },
                new Station() { Id = Guid.NewGuid(), Name = "Lorentzweiler" },
                new Station() { Id = Guid.NewGuid(), Name = "Luxembourg-Sud" },
                new Station() { Id = Guid.NewGuid(), Name = "Schouweiler" },
                new Station() { Id = Guid.NewGuid(), Name = "Betzdorf" },
                new Station() { Id = Guid.NewGuid(), Name = "Dudelange-Ville" },
                new Station() { Id = Guid.NewGuid(), Name = "Belval-Lycée" },
                new Station() { Id = Guid.NewGuid(), Name = "Bertrange-Strassen" },
                new Station() { Id = Guid.NewGuid(), Name = "Syren" },
                new Station() { Id = Guid.NewGuid(), Name = "Wasserbillig" },
                new Station() { Id = Guid.NewGuid(), Name = "Diekirch" },
                new Station() { Id = Guid.NewGuid(), Name = "Drauffelt" },
                new Station() { Id = Guid.NewGuid(), Name = "Mertert" },
                new Station() { Id = Guid.NewGuid(), Name = "Berchem" },
                new Station() { Id = Guid.NewGuid(), Name = "Livange" },
                new Station() { Id = Guid.NewGuid(), Name = "Lamadelaine" },
                new Station() { Id = Guid.NewGuid(), Name = "Capellen" },
                new Station() { Id = Guid.NewGuid(), Name = "Pfaffenthal-Kirchberg" },
                new Station() { Id = Guid.NewGuid(), Name = "Michelau" },
                new Station() { Id = Guid.NewGuid(), Name = "Howald" },
                new Station() { Id = Guid.NewGuid(), Name = "Rumelange" },
                new Station() { Id = Guid.NewGuid(), Name = "Wilwerwiltz" },
                new Station() { Id = Guid.NewGuid(), Name = "Mamer" },
                new Station() { Id = Guid.NewGuid(), Name = "Kayl" },
                new Station() { Id = Guid.NewGuid(), Name = "Merkholtz" },
                new Station() { Id = Guid.NewGuid(), Name = "Differdange(PA)" },
                new Station() { Id = Guid.NewGuid(), Name = "Oberkorn" },
                new Station() { Id = Guid.NewGuid(), Name = "Munsbach" },
                new Station() { Id = Guid.NewGuid(), Name = "Merkholtz Poste de block" },
                new Station() { Id = Guid.NewGuid(), Name = "Audun-le-Tiche" },
                new Station() { Id = Guid.NewGuid(), Name = "Bascharage-Sanem" },
                new Station() { Id = Guid.NewGuid(), Name = "Wecker" },
                new Station() { Id = Guid.NewGuid(), Name = "Ettelbruck" }
            };

            rawStations.ForEach(x =>
            {
                var ocp = OCPs.FirstOrDefault(y => x.Name == y.Name);
                x.OCPId = ocp?.Id ?? Guid.NewGuid();
            });

            Station[] Stations = rawStations.Where(x => x.OCPId != Guid.Empty).ToArray();


#pragma warning disable CS8602 // Dereference of a possibly null reference.
            List<Track> rawTracks = [
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Oberkorn", OCPToName = "Belvaux-Soleuvre" },
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Bettembourg frontière", OCPToName = "Bettembourg-Voyageurs"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Niederkorn", OCPToName = "Differdange(gare)"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Dudelange-Centre", OCPToName = "Dudelange-Usines"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Pétange", OCPToName = "Niederkorn"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Munsbach", OCPToName = "Roodt"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Colmar-Berg", OCPToName = "Schieren"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Dudelange-Usines", OCPToName = "Volmerange-les-Mines"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Drauffelt", OCPToName = "Mecher"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Dommeldange", OCPToName = "Walferdange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Belvaux-Soleuvre", OCPToName = "Belval-Rédange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Berchem Nord", OCPToName = "Berchem Est"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Fentange Sud(ligne 4)", OCPToName = "Berchem Est"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Cruchten", OCPToName = "Colmar-Berg"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Dudelange-Ville", OCPToName = "Dudelange-Centre"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Capellen", OCPToName = "Kleinbettingen"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Clervaux", OCPToName = "Maulusmuhle"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Ettelbruck", OCPToName = "Schieren Ligne 2"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Maulusmuhle", OCPToName = "Troisvierges"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Mecher", OCPToName = "Clervaux"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Rodange(secteur)", OCPToName = "Déviation vers 6h"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Merkholtz", OCPToName = "Paradiso"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Paradiso", OCPToName = "Wiltz"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Fentange Sud(ligne 4)", OCPToName = "Berchem Nord"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Berchem", OCPToName = "Berchem Nord"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg", OCPToName = "Cents-Hamm"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Berchem", OCPToName = "Fentange Sud(ligne 6)"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Wecker", OCPToName = "Manternach"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Sandweiler-Contern", OCPToName = "Oetrange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Syren", OCPToName = "Oetrange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Lamadelaine", OCPToName = "Rodange(secteur)"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Cents-Hamm", OCPToName = "Sandweiler-Contern"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Kayl", OCPToName = "Tétange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Bettembourg-Voyageurs", OCPToName = "Dudelange-Burange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Bettembourg-Voyageurs", OCPToName = "Noertzange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Scheuerbusch", OCPToName = "Schifflange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Belval-Lycée", OCPToName = "Belval-Université"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Belval-Université", OCPToName = "Belval-Usines"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Mersch", OCPToName = "Cruchten"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Walferdange", OCPToName = "Heisdorf"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Lintgen", OCPToName = "Mersch"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Bertrange-Strassen", OCPToName = "Mamer-Lycée"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Pfaffenthal-Kirchberg", OCPToName = "Dommeldange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Schouweiler", OCPToName = "Dippach-Reckange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Schifflange", OCPToName = "Esch-sur-Alzette"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Belval-Usines", OCPToName = "Esch-sur-Alzette"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Michelau", OCPToName = "Goebelsmuhle"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Goebelsmuhle", OCPToName = "Kautenbach"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg secteur Hollerich", OCPToName = "Luxembourg"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg-Triage", OCPToName = "Luxembourg"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Dippach-Reckange", OCPToName = "Leudelange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Leudelange", OCPToName = "Luxembourg secteur Hollerich"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Lorentzweiler", OCPToName = "Lintgen"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Heisdorf", OCPToName = "Lorentzweiler"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Bascharage-Sanem", OCPToName = "Schouweiler"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Roodt", OCPToName = "Betzdorf"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Dudelange-Burange", OCPToName = "Dudelange-Ville"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg", OCPToName = "Fentange Sud(ligne 4)"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Belval-Rédange", OCPToName = "Belval-Lycée"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Noertzange", OCPToName = "Brucherberg"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg", OCPToName = "Bertrange-Strassen"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Howald", OCPToName = "Luxembourg-Triage"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Berchem Est", OCPToName = "Syren"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Mertert", OCPToName = "Wasserbillig"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Ettelbruck", OCPToName = "Diekirch"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Ettelbruck", OCPToName = "Burden"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Wilwerwiltz", OCPToName = "Drauffelt"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Manternach", OCPToName = "Mertert"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Livange", OCPToName = "Berchem"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Bettembourg-Voyageurs", OCPToName = "Livange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Pétange", OCPToName = "Lamadelaine"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Mamer", OCPToName = "Capellen"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg", OCPToName = "Pfaffenthal-Kirchberg"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Burden", OCPToName = "Michelau"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Fentange Sud(ligne 6)", OCPToName = "Fentange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Fentange", OCPToName = "Howald"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Brucherberg", OCPToName = "Scheuerbusch"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Noertzange", OCPToName = "Scheuerbusch"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Tétange", OCPToName = "Rumelange"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Kautenbach", OCPToName = "Wilwerwiltz"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Colmar-Usines", OCPToName = "Bissen"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Schieren Ligne 2", OCPToName = "Colmar-Usines"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Tétange", OCPToName = "Langengrund"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Mamer-Lycée", OCPToName = "Mamer"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Brucherberg", OCPToName = "Kayl"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Kautenbach", OCPToName = "Merkholtz"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Differdange(gare)", OCPToName = "Differdange(PA)"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Differdange(PA)", OCPToName = "Oberkorn"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Oetrange", OCPToName = "Munsbach"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Pétange", OCPToName = "Bascharage-Sanem"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Betzdorf", OCPToName = "Wecker"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Schieren", OCPToName = "Ettelbruck"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Wasserbillig", OCPToName = "Wasserbillig frontière"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Déviation vers 6h", OCPToName = "Rodange frontière B A"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Troisvierges", OCPToName = "Troisvierges frontière"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Déviation vers 6h", OCPToName = "Rodange frontière B Aub"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Esch-sur-Alzette", OCPToName = "Esch-frontière"},
                new Track() { Id = Guid.NewGuid(), OCPFromName = "Kleinbettingen", OCPToName = "Kleinbettingen frontière"}
            ];
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            rawTracks.ForEach(x =>
            {
                var ocpFrom = OCPs.FirstOrDefault(y => x.OCPFromName == y.Name);
                var ocpTo = OCPs.FirstOrDefault(y => x.OCPToName == y.Name);

                x.OCPFromId = ocpFrom?.Id ?? Guid.NewGuid();
                x.OCPToId = ocpTo?.Id ?? Guid.NewGuid();
                x.Name = x.OCPFromName + " -> " + x.OCPToName;
            });
            Track[] Tracks = rawTracks.Where(x => x.OCPFromId != Guid.Empty && x.OCPToId != Guid.Empty).ToArray();

            return new Dictionary<Type, object[]>()
            {
                { typeof(Station), Stations },
                { typeof(OCP), OCPs },
                { typeof(Track), Tracks }
            };
        }

    }
}
