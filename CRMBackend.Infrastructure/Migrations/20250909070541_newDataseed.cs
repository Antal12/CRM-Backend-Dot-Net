using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRMBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newDataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "HR" },
                    { 3, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@crm.com", new byte[] { 63, 4, 152, 152, 138, 146, 103, 42, 108, 99, 146, 184, 228, 28, 72, 161, 182, 159, 71, 35, 14, 167, 194, 91, 31, 50, 114, 107, 208, 187, 109, 184, 86, 56, 63, 141, 163, 14, 152, 3, 210, 189, 203, 26, 214, 38, 234, 130, 229, 171, 177, 10, 47, 61, 189, 220, 140, 102, 179, 95, 56, 210, 72, 255 }, new byte[] { 211, 203, 53, 250, 152, 215, 112, 124, 185, 6, 219, 131, 124, 204, 108, 154, 29, 40, 188, 217, 166, 178, 248, 109, 30, 152, 200, 95, 143, 72, 147, 227, 98, 244, 69, 19, 121, 240, 153, 146, 105, 99, 52, 4, 73, 210, 155, 57, 113, 66, 43, 151, 202, 184, 231, 118, 3, 18, 47, 98, 24, 190, 209, 41, 48, 237, 234, 88, 244, 140, 57, 196, 3, 21, 188, 173, 196, 45, 206, 221, 232, 106, 246, 19, 129, 226, 82, 67, 27, 12, 194, 206, 223, 170, 39, 202, 3, 89, 79, 98, 179, 217, 17, 142, 215, 231, 253, 94, 0, 208, 185, 64, 174, 116, 93, 110, 216, 219, 211, 43, 139, 25, 185, 192, 101, 225, 14, 206 }, "Admin User" },
                    { 2, "hr@crm.com", new byte[] { 40, 162, 236, 75, 165, 241, 29, 127, 116, 29, 226, 236, 5, 201, 124, 200, 207, 21, 211, 146, 153, 113, 254, 12, 38, 196, 59, 50, 0, 192, 208, 247, 50, 202, 8, 164, 16, 169, 177, 12, 249, 214, 45, 120, 16, 0, 111, 15, 70, 142, 248, 74, 170, 108, 15, 9, 34, 155, 8, 185, 149, 231, 101, 114 }, new byte[] { 126, 14, 34, 155, 136, 225, 95, 222, 98, 122, 30, 61, 91, 141, 3, 192, 48, 109, 148, 119, 88, 34, 199, 207, 136, 198, 91, 180, 188, 113, 173, 224, 190, 84, 10, 82, 75, 86, 141, 35, 11, 17, 143, 71, 58, 134, 148, 12, 200, 59, 185, 86, 125, 126, 0, 223, 241, 81, 197, 193, 114, 68, 219, 51, 124, 83, 125, 127, 123, 38, 112, 49, 100, 152, 84, 37, 8, 249, 20, 81, 86, 227, 16, 188, 217, 39, 215, 34, 76, 91, 32, 83, 129, 88, 72, 69, 213, 152, 36, 67, 171, 31, 132, 44, 10, 138, 208, 20, 54, 87, 211, 160, 1, 108, 231, 155, 55, 43, 152, 26, 2, 169, 103, 167, 14, 101, 11, 159 }, "HR Manager" },
                    { 3, "user@crm.com", new byte[] { 187, 248, 110, 81, 120, 21, 138, 159, 68, 160, 6, 174, 243, 52, 157, 65, 50, 175, 140, 78, 251, 185, 177, 253, 120, 239, 26, 206, 143, 109, 43, 142, 90, 211, 39, 163, 92, 119, 129, 174, 31, 121, 208, 58, 151, 201, 30, 177, 78, 204, 105, 181, 100, 61, 141, 127, 49, 133, 85, 141, 80, 143, 134, 34 }, new byte[] { 35, 231, 162, 121, 88, 161, 234, 82, 218, 139, 130, 24, 54, 70, 59, 241, 125, 120, 199, 40, 123, 44, 165, 80, 215, 63, 14, 172, 74, 66, 52, 232, 93, 231, 84, 210, 219, 101, 250, 184, 167, 220, 25, 212, 229, 157, 0, 103, 40, 142, 169, 60, 36, 233, 146, 2, 3, 208, 194, 28, 100, 16, 63, 175, 88, 16, 203, 68, 202, 227, 238, 236, 163, 195, 179, 212, 36, 100, 192, 136, 7, 197, 124, 73, 10, 196, 104, 50, 4, 122, 190, 92, 105, 123, 22, 197, 151, 198, 206, 153, 234, 40, 136, 149, 22, 85, 94, 56, 66, 128, 152, 29, 189, 253, 204, 175, 69, 44, 128, 101, 196, 51, 165, 181, 241, 85, 95, 198 }, "Normal User" }
                });

            migrationBuilder.InsertData(
                table: "AuditLogs",
                columns: new[] { "AuditLogId", "Action", "Changes", "EntityName", "Timestamp", "UserId" },
                values: new object[,]
                {
                    { 1, "Created", "Added new customer ABC Corp", "Customer", new DateTime(2025, 9, 9, 7, 5, 40, 956, DateTimeKind.Utc).AddTicks(14), 1 },
                    { 2, "Updated", "Changed lead status to Contacted", "Lead", new DateTime(2025, 9, 9, 7, 5, 40, 956, DateTimeKind.Utc).AddTicks(18), 2 },
                    { 3, "Deleted", "Deleted quote with ID 3", "Quote", new DateTime(2025, 9, 9, 7, 5, 40, 956, DateTimeKind.Utc).AddTicks(20), 3 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AssignedToUserId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "contact@abc.com", "ABC Corp", "" },
                    { 2, 2, "info@xyz.com", "XYZ Ltd", "" },
                    { 3, 3, "sales@techsoft.com", "TechSoft", "" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "CreatedAt", "IsRead", "Message", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 9, 7, 5, 40, 956, DateTimeKind.Utc).AddTicks(53), false, "New Lead Assigned", 1 },
                    { 2, new DateTime(2025, 9, 9, 7, 5, 40, 956, DateTimeKind.Utc).AddTicks(62), false, "Invoice Paid", 2 },
                    { 3, new DateTime(2025, 9, 9, 7, 5, 40, 956, DateTimeKind.Utc).AddTicks(63), true, "Report Generated", 3 }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "CreatedAt", "GeneratedByUserId", "ReportType", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 9, 7, 5, 40, 955, DateTimeKind.Utc).AddTicks(9957), 1, "Sales", "Sales Report Q1" },
                    { 2, new DateTime(2025, 9, 9, 7, 5, 40, 955, DateTimeKind.Utc).AddTicks(9966), 2, "Financial", "Finance Report Q1" },
                    { 3, new DateTime(2025, 9, 9, 7, 5, 40, 955, DateTimeKind.Utc).AddTicks(9967), 3, "Customer", "Customer Report Q1" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Amount", "CreatedByUserId", "CustomerId", "Status" },
                values: new object[,]
                {
                    { 1, 1000m, 1, 1, "Pending" },
                    { 2, 2000m, 2, 2, "Paid" },
                    { 3, 3000m, 3, 3, "Overdue" }
                });

            migrationBuilder.InsertData(
                table: "Leads",
                columns: new[] { "LeadId", "CreatedByUserId", "CustomerId", "LeadName", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, "", "New" },
                    { 2, 2, 2, "", "Contacted" },
                    { 3, 3, 3, "", "Qualified" }
                });

            migrationBuilder.InsertData(
                table: "Opportunities",
                columns: new[] { "OpportunityId", "CustomerId", "OpportunityName", "OwnerUserId", "Stage" },
                values: new object[,]
                {
                    { 1, 1, "", 1, "Prospecting" },
                    { 2, 2, "", 2, "Negotiation" },
                    { 3, 3, "", 3, "ClosedWon" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Amount", "CreatedByUserId", "CustomerId", "OpportunityId", "Status" },
                values: new object[,]
                {
                    { 1, 0m, 1, 1, 1, "Draft" },
                    { 2, 0m, 2, 2, 2, "Sent" },
                    { 3, 0m, 3, 3, 3, "Approved" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "AuditLogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "AuditLogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuditLogs",
                keyColumn: "AuditLogId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "LeadId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "LeadId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "LeadId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "OpportunityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "OpportunityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "OpportunityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
