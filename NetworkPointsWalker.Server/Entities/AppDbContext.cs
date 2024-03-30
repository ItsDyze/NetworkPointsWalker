using Microsoft.EntityFrameworkCore;

namespace NetworkPointsWalker.Server.Entities
{
    public class AppDbContext:DbContext
    {
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

            modelBuilder.Entity<OCP>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Track>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Line>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            var Seed = SeedData();

            modelBuilder.Entity<Line>().HasData(Seed.GetValueOrDefault(typeof(Line)));
            modelBuilder.Entity<OCP>().HasData(Seed.GetValueOrDefault(typeof(OCP)));
            modelBuilder.Entity<Track>().HasData(Seed.GetValueOrDefault(typeof(Track)));
        }

        private Dictionary<Type, object[]> SeedData()
        {
            OCP[] OCPs = [
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,498, 5,952", Name = "Réseau tertiaire-Site Belval" }, //Fixed wrong data...
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,515, 5,9259", Name = "Belvaux-Soleuvre" },
                new() { Id = Guid.NewGuid(), IsChangePoint = true, GPS = "49,5161, 6,1011", Name = "Bettembourg-Voyageurs" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5224, 5,8916", Name = "Differdange(gare)" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4726, 6,0794", Name = "Dudelange-Usines" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5372, 5,8944", Name = "Niederkorn" },
                new() { Id = Guid.NewGuid(), IsChangePoint = true, GPS = "49,5541, 5,8786", Name = "Pétange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6663, 6,303", Name = "Roodt" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,8291, 6,095", Name = "Schieren" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4567, 6,079", Name = "Volmerange-les-Mines" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "50,0351, 6,01155", Name = "Mecher" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6619, 6,1363", Name = "Walferdange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5029, 5,9239", Name = "Belval-Rédange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5575, 6,1547", Name = "Berchem Est" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,8149, 6,10179", Name = "Colmar-Berg" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4788, 6,0822", Name = "Dudelange-Centre" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6439, 5,91741", Name = "Kleinbettingen" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "50,0941, 6,0258", Name = "Maulusmuhle" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,8294, 6,0949", Name = "Schieren Ligne 2" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "50,1192, 5,9909", Name = "Troisvierges" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "50,0613, 6,0247", Name = "Clervaux" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5506, 5,8372", Name = "Déviation vers 6h" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,9654, 5,95299", Name = "Paradiso" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,9666, 5,9283", Name = "Wiltz" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5525, 6,1418", Name = "Berchem Nord" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6152, 6,16667", Name = "Cents-Hamm" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5585, 6,1445", Name = "Fentange Sud(ligne 6)" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,7063, 6,4233", Name = "Manternach" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6025, 6,258", Name = "Oetrange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = true, GPS = "49,551, 5,8433", Name = "Rodange(secteur)" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,599, 6,21267", Name = "Sandweiler-Contern" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4774, 6,0348", Name = "Tétange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4925, 6,0862", Name = "Dudelange-Burange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,508, 6,0508", Name = "Noertzange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5063, 6,0094", Name = "Schifflange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4998, 5,9458", Name = "Belval-Université" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4958, 5,9586", Name = "Belval-Usines" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,7961, 6,1197", Name = "Cruchten" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6752, 6,1391", Name = "Heisdorf" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,7516, 6,1102", Name = "Mersch" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6183, 6,0297", Name = "Mamer-Lycée" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6338, 6,1363", Name = "Dommeldange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5725, 5,9951", Name = "Dippach-Reckange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4938, 5,9855", Name = "Esch-sur-Alzette" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,9211, 6,053", Name = "Goebelsmuhle" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,9486, 6,0222", Name = "Kautenbach" },
                new() { Id = Guid.NewGuid(), IsChangePoint = true, GPS = "49,5997, 6,1347", Name = "Luxembourg" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5869, 6,0581", Name = "Leudelange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5956, 6,1206", Name = "Luxembourg secteur Hollerich" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,7211, 6,1227", Name = "Lintgen" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6985, 6,14022", Name = "Lorentzweiler" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4727, 6,07943", Name = "Luxembourg-Sud" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5734, 5,9598", Name = "Schouweiler" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6888, 6,3486", Name = "Betzdorf" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4834, 6,083", Name = "Dudelange-Ville" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5607, 6,1457", Name = "Fentange Sud(ligne 4)" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5015, 5,934", Name = "Belval-Lycée" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4938, 6,1088", Name = "Bettembourg-Marchandises" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,501, 6,03863", Name = "Brucherberg" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6125, 6,0608", Name = "Bertrange-Strassen" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5898, 6,1341", Name = "Luxembourg-Triage" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5697, 6,2208", Name = "Syren" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,7127, 6,4991", Name = "Wasserbillig" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,8647, 6,1536", Name = "Diekirch" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,8764, 6,1054", Name = "Burden" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "50,0168, 6,00721", Name = "Drauffelt" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,7031, 6,47996", Name = "Mertert" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5425, 6,1336", Name = "Berchem" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5301, 6,118", Name = "Livange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5533, 5,8608", Name = "Lamadelaine" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6383, 5,9822", Name = "Capellen" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,551, 5,832", Name = "Réseau tertiaire-Rodange" }, //Fixed data..
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,619, 6,133", Name = "Pfaffenthal-Kirchberg" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,8966, 6,0919", Name = "Michelau" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5655, 6,1455", Name = "Fentange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5803, 6,1323", Name = "Howald" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5105, 6,0311", Name = "Scheuerbusch" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,46, 6,0325", Name = "Rumelange" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,9883, 6,0002", Name = "Wilwerwiltz" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,7884, 6,06931", Name = "Bissen" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,8078, 6,0926", Name = "Colmar-Usines" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4656, 6,0101", Name = "Langengrund" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6255, 6,02", Name = "Mamer" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5347, 5,8963", Name = "Réseau tertiaire-Site Differdange" }, // Fixed data...
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4857, 6,0352", Name = "Kayl" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,9566, 5,9816", Name = "Merkholtz" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5224, 5,89157", Name = "Differdange(PA)" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5104, 5,89133", Name = "Oberkorn" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6305, 6,2683", Name = "Munsbach" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6256, 6,02", Name = "Merkholtz Poste de block" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4783, 5,9582", Name = "Audun-le-Tiche" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5585, 5,92509", Name = "Bascharage-Sanem" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,7, 6,3863", Name = "Wecker" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,8472, 6,1066", Name = "Ettelbruck" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,7138, 6,5066", Name = "Wasserbillig frontière" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5518, 5,8106", Name = "Rodange frontière B A" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "50,173, 5,9653", Name = "Troisvierges frontière" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5518, 5,825", Name = "Rodange frontière B Aub" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4859, 5,9688", Name = "Esch-frontière" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,6437, 5,9042", Name = "Kleinbettingen frontière" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,4721, 6,10784", Name = "Bettembourg frontière" },
                new() { Id = Guid.NewGuid(), IsChangePoint = false, GPS = "49,5433, 5,8106", Name = "Rodange frontière francaise" },
            ];

            List<Line> lines = new List<Line>(){
                new() { Id = Guid.NewGuid(), Name = "L10" },
                new() { Id = Guid.NewGuid(), Name = "L30" },
                new() { Id = Guid.NewGuid(), Name = "L50" },
                new() { Id = Guid.NewGuid(), Name = "L60" },
                new() { Id = Guid.NewGuid(), Name = "L70" },
                new() { Id = Guid.NewGuid(), Name = "L90" },
            };


#pragma warning disable CS8602 // Dereference of a possibly null reference.
            List<Track> rawTracks = [
                new() { Id = Guid.NewGuid(), OCPFromName = "Oberkorn", OCPToName = "Belvaux-Soleuvre" },
                new() { Id = Guid.NewGuid(), OCPFromName = "Bettembourg frontière", OCPToName = "Bettembourg-Voyageurs"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Niederkorn", OCPToName = "Differdange(gare)"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Dudelange-Centre", OCPToName = "Dudelange-Usines"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Pétange", OCPToName = "Niederkorn"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Munsbach", OCPToName = "Roodt"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Colmar-Berg", OCPToName = "Schieren"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Dudelange-Usines", OCPToName = "Volmerange-les-Mines"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Drauffelt", OCPToName = "Mecher"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Dommeldange", OCPToName = "Walferdange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Belvaux-Soleuvre", OCPToName = "Belval-Rédange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Berchem Nord", OCPToName = "Berchem Est"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Fentange Sud(ligne 4)", OCPToName = "Berchem Est"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Cruchten", OCPToName = "Colmar-Berg"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Dudelange-Ville", OCPToName = "Dudelange-Centre"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Capellen", OCPToName = "Kleinbettingen"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Clervaux", OCPToName = "Maulusmuhle"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Ettelbruck", OCPToName = "Schieren Ligne 2"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Maulusmuhle", OCPToName = "Troisvierges"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Mecher", OCPToName = "Clervaux"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Rodange(secteur)", OCPToName = "Déviation vers 6h"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Merkholtz", OCPToName = "Paradiso"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Paradiso", OCPToName = "Wiltz"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Fentange Sud(ligne 4)", OCPToName = "Berchem Nord"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Berchem", OCPToName = "Berchem Nord"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg", OCPToName = "Cents-Hamm"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Berchem", OCPToName = "Fentange Sud(ligne 6)"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Wecker", OCPToName = "Manternach"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Sandweiler-Contern", OCPToName = "Oetrange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Syren", OCPToName = "Oetrange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Lamadelaine", OCPToName = "Rodange(secteur)"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Cents-Hamm", OCPToName = "Sandweiler-Contern"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Kayl", OCPToName = "Tétange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Bettembourg-Voyageurs", OCPToName = "Dudelange-Burange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Bettembourg-Voyageurs", OCPToName = "Noertzange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Scheuerbusch", OCPToName = "Schifflange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Belval-Lycée", OCPToName = "Belval-Université"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Belval-Université", OCPToName = "Belval-Usines"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Mersch", OCPToName = "Cruchten"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Walferdange", OCPToName = "Heisdorf"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Lintgen", OCPToName = "Mersch"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Bertrange-Strassen", OCPToName = "Mamer-Lycée"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Pfaffenthal-Kirchberg", OCPToName = "Dommeldange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Schouweiler", OCPToName = "Dippach-Reckange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Schifflange", OCPToName = "Esch-sur-Alzette"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Belval-Usines", OCPToName = "Esch-sur-Alzette"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Michelau", OCPToName = "Goebelsmuhle"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Goebelsmuhle", OCPToName = "Kautenbach"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg secteur Hollerich", OCPToName = "Luxembourg"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg-Triage", OCPToName = "Luxembourg"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Dippach-Reckange", OCPToName = "Leudelange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Leudelange", OCPToName = "Luxembourg secteur Hollerich"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Lorentzweiler", OCPToName = "Lintgen"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Heisdorf", OCPToName = "Lorentzweiler"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Bascharage-Sanem", OCPToName = "Schouweiler"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Roodt", OCPToName = "Betzdorf"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Dudelange-Burange", OCPToName = "Dudelange-Ville"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg", OCPToName = "Fentange Sud(ligne 4)"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Belval-Rédange", OCPToName = "Belval-Lycée"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Noertzange", OCPToName = "Brucherberg"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg", OCPToName = "Bertrange-Strassen"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Howald", OCPToName = "Luxembourg-Triage"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Berchem Est", OCPToName = "Syren"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Mertert", OCPToName = "Wasserbillig"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Ettelbruck", OCPToName = "Diekirch"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Ettelbruck", OCPToName = "Burden"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Wilwerwiltz", OCPToName = "Drauffelt"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Manternach", OCPToName = "Mertert"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Livange", OCPToName = "Berchem"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Bettembourg-Voyageurs", OCPToName = "Livange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Pétange", OCPToName = "Lamadelaine"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Mamer", OCPToName = "Capellen"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Luxembourg", OCPToName = "Pfaffenthal-Kirchberg"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Burden", OCPToName = "Michelau"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Fentange Sud(ligne 6)", OCPToName = "Fentange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Fentange", OCPToName = "Howald"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Brucherberg", OCPToName = "Scheuerbusch"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Noertzange", OCPToName = "Scheuerbusch"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Tétange", OCPToName = "Rumelange"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Kautenbach", OCPToName = "Wilwerwiltz"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Colmar-Usines", OCPToName = "Bissen"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Schieren Ligne 2", OCPToName = "Colmar-Usines"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Tétange", OCPToName = "Langengrund"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Mamer-Lycée", OCPToName = "Mamer"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Brucherberg", OCPToName = "Kayl"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Kautenbach", OCPToName = "Merkholtz"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Differdange(gare)", OCPToName = "Differdange(PA)"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Differdange(PA)", OCPToName = "Oberkorn"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Oetrange", OCPToName = "Munsbach"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Pétange", OCPToName = "Bascharage-Sanem"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Betzdorf", OCPToName = "Wecker"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Schieren", OCPToName = "Ettelbruck"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Wasserbillig", OCPToName = "Wasserbillig frontière"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Déviation vers 6h", OCPToName = "Rodange frontière B A"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Troisvierges", OCPToName = "Troisvierges frontière"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Déviation vers 6h", OCPToName = "Rodange frontière B Aub"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Esch-sur-Alzette", OCPToName = "Esch-frontière"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Kleinbettingen", OCPToName = "Kleinbettingen frontière"},
                new() { Id = Guid.NewGuid(), OCPFromName = "Esch-sur-Alzette", OCPToName = "Audun-le-Tiche" }
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
                { typeof(Line), lines.ToArray() },
                { typeof(OCP), OCPs },
                { typeof(Track), Tracks }
            };
        }

    }
}
