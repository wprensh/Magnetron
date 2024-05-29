USE [MAGNETRON]
GO
/****** Object:  Table [dbo].[facturadetalle]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturadetalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fdet_linea] [int] NULL,
	[fdet_cantidad] [int] NULL,
	[fdet_prod_id] [int] NULL,
	[fdet_fenc_id] [int] NULL,
	[fdet_prod_precio] [decimal](18, 0) NULL,
	[fdet_prod_utilidad] [decimal](18, 0) NULL,
 CONSTRAINT [PK_facturadetalle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturaencabezado]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturaencabezado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fenc_numero] [int] NULL,
	[fenc_fecha] [date] NULL,
	[per_id] [int] NULL,
 CONSTRAINT [PK_facturaencabezado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturaresumen]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturaresumen](
	[fenc_id] [int] NOT NULL,
	[fres_total] [decimal](18, 0) NOT NULL,
	[max_prod_id] [int] NULL,
 CONSTRAINT [facturaresumen_pk] PRIMARY KEY CLUSTERED 
(
	[fenc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[per_nombre] [varchar](100) NULL,
	[per_apellidos] [varchar](100) NULL,
	[per_tipodoc] [int] NULL,
	[per_identificacion] [varchar](100) NULL,
 CONSTRAINT [PK_persona] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pord_desc] [varchar](100) NULL,
	[prod_precio] [decimal](18, 0) NULL,
	[prod_costo] [decimal](18, 0) NULL,
	[prod_um] [varchar](50) NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[facturadetalle] ON 

INSERT [dbo].[facturadetalle] ([id], [fdet_linea], [fdet_cantidad], [fdet_prod_id], [fdet_fenc_id], [fdet_prod_precio], [fdet_prod_utilidad]) VALUES (1, 1, 1, 1, 1, CAST(8000000 AS Decimal(18, 0)), CAST(1000000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[facturadetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[facturaencabezado] ON 

INSERT [dbo].[facturaencabezado] ([id], [fenc_numero], [fenc_fecha], [per_id]) VALUES (1, 10001, CAST(N'2024-05-28' AS Date), 1)
SET IDENTITY_INSERT [dbo].[facturaencabezado] OFF
GO
INSERT [dbo].[facturaresumen] ([fenc_id], [fres_total], [max_prod_id]) VALUES (1, CAST(8000000 AS Decimal(18, 0)), 1)
GO
SET IDENTITY_INSERT [dbo].[persona] ON 

INSERT [dbo].[persona] ([id], [per_nombre], [per_apellidos], [per_tipodoc], [per_identificacion]) VALUES (1, N'Walter', N'Prens', 1, N'1001')
INSERT [dbo].[persona] ([id], [per_nombre], [per_apellidos], [per_tipodoc], [per_identificacion]) VALUES (2, N'Joseph', N'Moreno', 1, N'1002')
SET IDENTITY_INSERT [dbo].[persona] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([id], [pord_desc], [prod_precio], [prod_costo], [prod_um]) VALUES (1, N'Transformador de Distribución Convencional', CAST(8000000 AS Decimal(18, 0)), CAST(7000000 AS Decimal(18, 0)), N'5 kVA')
INSERT [dbo].[producto] ([id], [pord_desc], [prod_precio], [prod_costo], [prod_um]) VALUES (2, N'Transformador de Potencia', CAST(7000000 AS Decimal(18, 0)), CAST(6000000 AS Decimal(18, 0)), N'500 kVA')
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
/****** Object:  Index [facturadetalle_linea_factura]    Script Date: 28/05/2024 11:33:35 p. m. ******/
ALTER TABLE [dbo].[facturadetalle] ADD  CONSTRAINT [facturadetalle_linea_factura] UNIQUE NONCLUSTERED 
(
	[fdet_linea] ASC,
	[fdet_fenc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [ix_persona]    Script Date: 28/05/2024 11:33:35 p. m. ******/
ALTER TABLE [dbo].[persona] ADD  CONSTRAINT [ix_persona] UNIQUE NONCLUSTERED 
(
	[per_tipodoc] ASC,
	[per_identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[facturaresumen] ADD  DEFAULT ((0)) FOR [fres_total]
GO
ALTER TABLE [dbo].[facturaresumen] ADD  DEFAULT (NULL) FOR [max_prod_id]
GO
ALTER TABLE [dbo].[facturadetalle]  WITH CHECK ADD  CONSTRAINT [facturadetalle_facturaencabezado_FK] FOREIGN KEY([fdet_fenc_id])
REFERENCES [dbo].[facturaencabezado] ([id])
GO
ALTER TABLE [dbo].[facturadetalle] CHECK CONSTRAINT [facturadetalle_facturaencabezado_FK]
GO
ALTER TABLE [dbo].[facturadetalle]  WITH CHECK ADD  CONSTRAINT [facturadetalle_producto_FK] FOREIGN KEY([fdet_prod_id])
REFERENCES [dbo].[producto] ([id])
GO
ALTER TABLE [dbo].[facturadetalle] CHECK CONSTRAINT [facturadetalle_producto_FK]
GO
ALTER TABLE [dbo].[facturaencabezado]  WITH CHECK ADD  CONSTRAINT [facturaencabezado_persona_FK] FOREIGN KEY([per_id])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[facturaencabezado] CHECK CONSTRAINT [facturaencabezado_persona_FK]
GO
ALTER TABLE [dbo].[facturaresumen]  WITH CHECK ADD  CONSTRAINT [facturaresumen_facturaencabezado_FK] FOREIGN KEY([fenc_id])
REFERENCES [dbo].[facturaencabezado] ([id])
GO
ALTER TABLE [dbo].[facturaresumen] CHECK CONSTRAINT [facturaresumen_facturaencabezado_FK]
GO
ALTER TABLE [dbo].[facturaresumen]  WITH CHECK ADD  CONSTRAINT [facturaresumen_producto_FK] FOREIGN KEY([max_prod_id])
REFERENCES [dbo].[producto] ([id])
GO
ALTER TABLE [dbo].[facturaresumen] CHECK CONSTRAINT [facturaresumen_producto_FK]
GO
ALTER TABLE [dbo].[facturadetalle]  WITH NOCHECK ADD  CONSTRAINT [facturadetalle_ck] CHECK  (([fdet_prod_precio]>(0) AND [fdet_cantidad]>(0)))
GO
ALTER TABLE [dbo].[facturadetalle] CHECK CONSTRAINT [facturadetalle_ck]
GO
/****** Object:  StoredProcedure [dbo].[pa_listado_persona]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pa_listado_persona]
AS 
SELECT p.id , p.per_nombre, p.per_apellidos, p.per_tipodoc, p.per_identificacion, ISNULL(SUM(r.fres_total), 0) AS total_fac
FROM persona p(NOLOCK)
LEFT JOIN facturaencabezado f(NOLOCK) ON p.id  = f.per_id 
LEFT JOIN facturaresumen r(NOLOCK) ON f.id = r.fenc_id
GROUP BY p.id , p.per_nombre, p.per_apellidos, p.per_tipodoc, p.per_identificacion;

GO
/****** Object:  StoredProcedure [dbo].[pa_listado_producto_cantidad]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pa_listado_producto_cantidad]
AS 
SELECT p.id, p.pord_desc, p.prod_precio, p.prod_costo, ISNULL(SUM(d.fdet_cantidad), 0) as cant_facturada
FROM producto p(NOLOCK)
LEFT JOIN facturadetalle d(NOLOCK) ON p.id = d.fdet_prod_id
GROUP BY p.id, p.pord_desc, p.prod_precio, p.prod_costo
ORDER BY cant_facturada DESC, p.pord_desc;

GO
/****** Object:  StoredProcedure [dbo].[pa_listado_producto_margen]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pa_listado_producto_margen]
AS 
SELECT 
	p.id, p.pord_desc, p.prod_precio, p.prod_costo, 
	ISNULL(CONVERT(DECIMAL(23,3), 100.000) * SUM(d.fdet_prod_utilidad) / SUM(d.fdet_cantidad * d.fdet_prod_precio), 0) as margen
FROM producto p(NOLOCK)
LEFT JOIN facturadetalle d(NOLOCK) ON p.id = d.fdet_prod_id
GROUP BY p.id, p.pord_desc, p.prod_precio, p.prod_costo
ORDER BY margen DESC, p.pord_desc;

GO
/****** Object:  StoredProcedure [dbo].[pa_listado_producto_utilidad]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pa_listado_producto_utilidad]
AS 
SELECT 
	p.id, p.pord_desc, p.prod_precio, p.prod_costo, ISNULL(SUM(d.fdet_prod_utilidad), 0) as utilidad
FROM producto p(NOLOCK)
LEFT JOIN facturadetalle d(NOLOCK) ON p.id = d.fdet_prod_id
GROUP BY p.id, p.pord_desc, p.prod_precio, p.prod_costo
ORDER BY utilidad DESC, p.pord_desc;

GO
/****** Object:  StoredProcedure [dbo].[pa_persona_producto_max]    Script Date: 28/05/2024 11:33:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pa_persona_producto_max]
AS 
SELECT 
	p.id , p.per_nombre, p.per_apellidos, p.per_tipodoc, p.per_identificacion,
	p.id as prod_id, m.fdet_prod_precio as prod_precio
FROM persona p(NOLOCK)
INNER JOIN (
	SELECT TOP(1) f.per_id, r.max_prod_id, d.fdet_prod_precio 
	FROM facturaencabezado f(NOLOCK)
	INNER JOIN facturaresumen r(NOLOCK) ON f.id = r.fenc_id
	INNER JOIN facturadetalle d(NOLOCK) ON f.id  = d.fdet_fenc_id AND r.max_prod_id = d.fdet_prod_id
	ORDER BY d.fdet_prod_precio DESC, f.fenc_fecha DESC
) m ON p.id = m.per_id
INNER JOIN producto pp(NOLOCK) ON pp.id = m.max_prod_id;
GO
