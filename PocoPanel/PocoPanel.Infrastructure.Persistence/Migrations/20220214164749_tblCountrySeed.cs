using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblCountrySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblCountry",
                columns: new[] { "Id", "Name", "ParentID" },
                values: new object[,]
                {
                    { 1, "Afghanistan", null },
                    { 159, "New Caledonia", null },
                    { 160, "New Zealand", null },
                    { 161, "Nicaragua", null },
                    { 162, "Niger", null },
                    { 163, "Nigeria", null },
                    { 164, "Niue", null },
                    { 165, "Norfolk Island", null },
                    { 166, "Northern Mariana Islands", null },
                    { 167, "Norway", null },
                    { 168, "Oman", null },
                    { 169, "Pakistan", null },
                    { 170, "Palau", null },
                    { 171, "Palestine, State of", null },
                    { 172, "Panama", null },
                    { 173, "Papua New Guinea", null },
                    { 174, "Paraguay", null },
                    { 175, "Peru", null },
                    { 176, "Philippines", null },
                    { 177, "Pitcairn", null },
                    { 178, "Poland", null },
                    { 179, "Portugal", null },
                    { 180, "Puerto Rico", null },
                    { 181, "Qatar", null },
                    { 182, "Réunion", null },
                    { 183, "Romania", null },
                    { 184, "Russian Federation", null },
                    { 185, "Rwanda", null },
                    { 158, "Netherlands", null },
                    { 186, "Saint Barthélemy", null },
                    { 157, "Nepal", null },
                    { 155, "Namibia", null },
                    { 128, "Libya", null },
                    { 129, "Liechtenstein", null },
                    { 130, "Lithuania", null },
                    { 131, "Luxembourg", null },
                    { 132, "Macao", null },
                    { 133, "Macedonia, the Former Yugoslav Republic of", null },
                    { 134, "Madagascar", null },
                    { 135, "Malawi", null },
                    { 136, "Malaysia", null },
                    { 137, "Maldives", null },
                    { 138, "Mali", null },
                    { 139, "Malta", null },
                    { 140, "Marshall Islands", null },
                    { 141, "Martinique", null },
                    { 142, "Mauritania", null },
                    { 143, "Mauritius", null },
                    { 144, "Mayotte", null },
                    { 145, "Mexico", null },
                    { 146, "Micronesia, Federated States of", null },
                    { 147, "Moldova, Republic of", null },
                    { 148, "Monaco", null },
                    { 149, "Mongolia", null },
                    { 150, "Montenegro", null },
                    { 151, "Montserrat", null },
                    { 152, "Morocco", null },
                    { 153, "Mozambique", null },
                    { 154, "Myanmar", null },
                    { 156, "Nauru", null },
                    { 187, "Saint Helena, Ascension and Tristan da Cunha", null },
                    { 188, "Saint Kitts and Nevis", null },
                    { 189, "Saint Lucia", null },
                    { 222, "Thailand", null },
                    { 223, "Timor-Leste", null },
                    { 224, "Togo", null },
                    { 225, "Tokelau", null },
                    { 226, "Tonga", null },
                    { 227, "Trinidad and Tobago", null },
                    { 228, "Tunisia", null },
                    { 229, "Turkey", null },
                    { 230, "Turkmenistan", null },
                    { 231, "Turks and Caicos Islands", null },
                    { 232, "Tuvalu", null },
                    { 233, "Uganda", null },
                    { 234, "Ukraine", null },
                    { 235, "United Arab Emirates", null },
                    { 236, "United Kingdom", null },
                    { 237, "United States", null },
                    { 238, "United States Minor Outlying Islands", null },
                    { 239, "Uruguay", null },
                    { 240, "Uzbekistan", null },
                    { 241, "Vanuatu", null },
                    { 242, "Venezuela, Bolivarian Republic of", null },
                    { 243, "Viet Nam", null },
                    { 244, "Virgin Islands, British", null },
                    { 245, "Virgin Islands, U.S.", null },
                    { 246, "Wallis and Futuna", null },
                    { 247, "Western Sahara", null },
                    { 248, "Yemen", null },
                    { 221, "Tanzania, United Republic of", null },
                    { 220, "Tajikistan", null },
                    { 219, "Taiwan, Province of China", null },
                    { 218, "Syrian Arab Republic", null },
                    { 190, "Saint Martin (French part)", null },
                    { 191, "Saint Pierre and Miquelon", null },
                    { 192, "Saint Vincent and the Grenadines", null },
                    { 193, "Samoa", null },
                    { 194, "San Marino", null },
                    { 195, "Sao Tome and Principe", null },
                    { 196, "Saudi Arabia", null },
                    { 197, "Senegal", null },
                    { 198, "Serbia", null },
                    { 199, "Seychelles", null },
                    { 200, "Sierra Leone", null },
                    { 201, "Singapore", null },
                    { 202, "Sint Maarten (Dutch part)", null },
                    { 127, "Liberia", null },
                    { 203, "Slovakia", null },
                    { 205, "Solomon Islands", null },
                    { 206, "Somalia", null },
                    { 207, "South Africa", null },
                    { 208, "South Georgia and the South Sandwich Islands", null },
                    { 209, "South Sudan", null },
                    { 210, "Spain", null },
                    { 211, "Sri Lanka", null },
                    { 212, "Sudan", null },
                    { 213, "Suriname", null },
                    { 214, "Svalbard and Jan Mayen", null },
                    { 215, "Swaziland", null },
                    { 216, "Sweden", null },
                    { 217, "Switzerland", null },
                    { 204, "Slovenia", null },
                    { 249, "Zambia", null },
                    { 126, "Lesotho", null },
                    { 124, "Latvia", null },
                    { 34, "British Indian Ocean Territory", null },
                    { 35, "Brunei Darussalam", null },
                    { 36, "Bulgaria", null },
                    { 37, "Burkina Faso", null },
                    { 38, "Burundi", null },
                    { 39, "Cambodia", null },
                    { 40, "Cameroon", null },
                    { 41, "Canada", null },
                    { 42, "Cape Verde", null },
                    { 43, "Cayman Islands", null },
                    { 44, "Central African Republic", null },
                    { 45, "Chad", null },
                    { 46, "Chile", null },
                    { 47, "China", null },
                    { 48, "Christmas Island", null },
                    { 49, "Cocos (Keeling) Islands", null },
                    { 50, "Colombia", null },
                    { 51, "Comoros", null },
                    { 52, "Congo", null },
                    { 53, "Congo, the Democratic Republic of the", null },
                    { 54, "Cook Islands", null },
                    { 55, "Costa Rica", null },
                    { 56, "Côte d'Ivoire", null },
                    { 57, "Croatia", null },
                    { 58, "Cuba", null },
                    { 59, "Curaçao", null },
                    { 60, "Cyprus", null },
                    { 33, "Brazil", null },
                    { 61, "Czech Republic", null },
                    { 32, "Bouvet Island", null },
                    { 30, "Bosnia and Herzegovina", null },
                    { 2, "Åland Islands", null },
                    { 3, "Albania", null },
                    { 4, "Algeria", null },
                    { 5, "American Samoa", null },
                    { 6, "Andorra", null },
                    { 7, "Angola", null },
                    { 8, "Anguilla", null },
                    { 9, "Antarctica", null },
                    { 10, "Antigua and Barbuda", null },
                    { 12, "Argentina", null },
                    { 13, "Armenia", null },
                    { 14, "Aruba", null },
                    { 15, "Australia", null },
                    { 16, "Austria", null },
                    { 17, "Azerbaijan", null },
                    { 18, "Bahrain", null },
                    { 19, "Bahamas", null },
                    { 20, "Bangladesh", null },
                    { 21, "Barbados", null },
                    { 22, "Belarus", null },
                    { 23, "Belgium", null },
                    { 24, "Belize", null },
                    { 25, "Benin", null },
                    { 26, "Bermuda", null },
                    { 27, "Bhutan", null },
                    { 28, "Bolivia, Plurinational State of", null },
                    { 29, "Bonaire, Sint Eustatius and Saba", null },
                    { 31, "Botswana", null },
                    { 62, "Denmark", null },
                    { 63, "Djibouti", null },
                    { 64, "Dominica", null },
                    { 97, "Haiti", null },
                    { 98, "Heard Island and McDonald Islands", null },
                    { 99, "Holy See (Vatican City State)", null },
                    { 100, "Honduras", null },
                    { 101, "Hong Kong", null },
                    { 102, "Hungary", null },
                    { 103, "Iceland", null },
                    { 104, "India", null },
                    { 105, "Indonesia", null },
                    { 106, "Iran, Islamic Republic of", null },
                    { 107, "Iraq", null },
                    { 108, "Ireland", null },
                    { 109, "Isle of Man", null },
                    { 110, "Israel", null },
                    { 111, "Italy", null },
                    { 112, "Jamaica", null },
                    { 113, "Japan", null },
                    { 114, "Jersey", null },
                    { 115, "Jordan", null },
                    { 116, "Kazakhstan", null },
                    { 117, "Kenya", null },
                    { 118, "Kiribati", null },
                    { 119, "Korea, Democratic People's Republic of", null },
                    { 120, "Korea, Republic of", null },
                    { 121, "Kuwait", null },
                    { 122, "Kyrgyzstan", null },
                    { 123, "Lao People's Democratic Republic", null },
                    { 96, "Guyana", null },
                    { 95, "Guinea-Bissau", null },
                    { 94, "Guinea", null },
                    { 93, "Guernsey", null },
                    { 65, "Dominican Republic", null },
                    { 66, "Ecuador", null },
                    { 67, "Egypt", null },
                    { 68, "El Salvador", null },
                    { 69, "Equatorial Guinea", null },
                    { 70, "Eritrea", null },
                    { 71, "Estonia", null },
                    { 72, "Ethiopia", null },
                    { 73, "Falkland Islands (Malvinas)", null },
                    { 74, "Faroe Islands", null },
                    { 75, "Fiji", null },
                    { 76, "Finland", null },
                    { 77, "France", null },
                    { 125, "Lebanon", null },
                    { 78, "French Guiana", null },
                    { 80, "French Southern Territories", null },
                    { 81, "Gabon", null },
                    { 82, "Gambia", null },
                    { 83, "Georgia", null },
                    { 84, "Germany", null },
                    { 85, "Ghana", null },
                    { 86, "Gibraltar", null },
                    { 87, "Greece", null },
                    { 88, "Greenland", null },
                    { 89, "Grenada", null },
                    { 90, "Guadeloupe", null },
                    { 91, "Guam", null },
                    { 92, "Guatemala", null },
                    { 79, "French Polynesia", null },
                    { 250, "Zimbabwe", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.UpdateData(
                table: "tblPriceKind",
                keyColumn: "Id",
                keyValue: 1,
                column: "tblCountryId",
                value: null);
        }
    }
}
