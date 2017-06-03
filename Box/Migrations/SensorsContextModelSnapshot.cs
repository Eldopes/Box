using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Box.Models.Sensors;

namespace Box.Migrations
{
    [DbContext(typeof(SensorsContext))]
    partial class SensorsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Box.Models.Indication", b =>
                {
                    b.Property<int>("IndicationID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<double>("IndicationData");

                    b.Property<int>("SensorID");

                    b.HasKey("IndicationID");

                    b.HasIndex("SensorID");

                    b.ToTable("Indications");
                });

            modelBuilder.Entity("Box.Models.Sensor", b =>
                {
                    b.Property<int>("SensorID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name");

                    b.Property<string>("Scale");

                    b.HasKey("SensorID");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("Box.Models.Indication", b =>
                {
                    b.HasOne("Box.Models.Sensor")
                        .WithMany("Indications")
                        .HasForeignKey("SensorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
