using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChannelAnalysis.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalysisQueue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    channellink = table.Column<string>(name: "channel_link", type: "text", nullable: true),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisQueue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    idchannel = table.Column<long>(name: "id_channel", type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    channelname = table.Column<string>(name: "channel_name", type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.idchannel);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackStorage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idreview = table.Column<string>(name: "id_review", type: "character varying(32)", maxLength: 32, nullable: true),
                    content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackStorage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChannelStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idchannel = table.Column<long>(name: "id_channel", type: "bigint", nullable: false),
                    viewstotalcount = table.Column<long>(name: "views_total_count", type: "bigint", nullable: false),
                    forwardstotalcount = table.Column<long>(name: "forwards_total_count", type: "bigint", nullable: false),
                    reactionstotalcount = table.Column<string>(name: "reactions_total_count", type: "jsonb", nullable: true),
                    lastpublicationdate = table.Column<DateTime>(name: "last_publication_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelStatistics_Channel_id_channel",
                        column: x => x.idchannel,
                        principalTable: "Channel",
                        principalColumn: "id_channel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProrussianCoefficient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    calculatedcoefficient = table.Column<float>(name: "calculated_coefficient", type: "real", nullable: false),
                    idchannel = table.Column<long>(name: "id_channel", type: "bigint", nullable: false),
                    lastpublicationdate = table.Column<DateTime>(name: "last_publication_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProrussianCoefficient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProrussianCoefficient_Channel_id_channel",
                        column: x => x.idchannel,
                        principalTable: "Channel",
                        principalColumn: "id_channel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelStatistics_id_channel",
                table: "ChannelStatistics",
                column: "id_channel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProrussianCoefficient_id_channel",
                table: "ProrussianCoefficient",
                column: "id_channel",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisQueue");

            migrationBuilder.DropTable(
                name: "ChannelStatistics");

            migrationBuilder.DropTable(
                name: "FeedbackStorage");

            migrationBuilder.DropTable(
                name: "ProrussianCoefficient");

            migrationBuilder.DropTable(
                name: "Channel");
        }
    }
}
