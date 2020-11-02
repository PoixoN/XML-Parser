<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html"/>
	<xsl:template match="/">
		<html>
			<body>
				<style>
					body {
					color: white;
					background-color: grey;
					}
					table {
					margin-left: auto;
					margin-right: auto;
					}
					th {
					font-weight: bold;
					}
					tr:hover {
					color: black;
					background-color: lightgrey;
					}
				</style>
				
				<h1>GamesDataBase by Lubomyr</h1>
				
				<table border="1" width="1200">
					<tr>
						<th>Name</th>
						<th>Genre</th>
						<th>Year</th>
						<th>Company</th>
						<th>Rating</th>
						<th>Price</th>
					</tr>
					<xsl:for-each select="GamesDataBase/Game">
						<tr>
							<td>
								<xsl:value-of select="@Name"/>
							</td>
							<td>
								<xsl:value-of select="@Genre"/>
							</td>
							<td>
								<xsl:value-of select="@Year"/>
							</td>
							<td>
								<xsl:value-of select="@Company"/>
							</td>
							<td>
								<xsl:value-of select="@Rating"/>
							</td>
							<td>
								<xsl:value-of select="@Price"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>