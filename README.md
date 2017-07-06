Proyecto queComemos:

  Idea:

    - Aplicación para registrar recetas , ingredientes y comercios. Búsqueda de recetas, Búsquedas de costos de compras, tiempo de cocción, búsqueda de ingredientes acordes para cocinar. Ademas un perfil que gestione las comidas semanales para realizar, un seguimiento nutricional y poder decidir la próxima comida.

    - Base de datos SQL y front en C# form.

    - Proyecto en gihub: https://github.com/hellfishg/queComemos



  Partes:

    Recetas:
      [ ] Link  de imagen de la receta.
      [ ] Texto de la receta.
      [ ] Tipo de recetas. @Homnívoro-Vegetariano-Vegano-Celiaco.
      [ ] Ingredientes, cantidad.
      [ ] Tiempo aprox. de preparación.
      [ ] Costo total aproximado. @Seleccionar la cantidad de personas.
      [ ] Indices total Calorías,Proteínas, carbohidratos, grasas. @CPCG 

    Ingredientes:
      [ ] Costo por unidad.
      [ ] @CPCG
      [ ] Tipo de ingrediente @gramos-unidad-litros

    Perfiles:
      [ ] Nombre
      [ ] Avatar
      [ ] Consumo de @CPCG*  en calendario.

    Lugares de compra:
      [ ] Nombre
      [ ] Ingredientes
      [ ] Dirección

    Busquedas:
      [ ] Por Receta.
      [ ] Por Perfil.
      [ ] Por Tipos.
      [ ] Por Costo.
      [ ] Por Ingredientes preexistentes.
      [ ] Por Prioridad de @CPCG
      [ ] Búsqueda Random que no se comió en la semana.
      [ ] Lista de compras y en donde comprar cada cosa.
      [ ] La receta mas adecuada a los ingredientes que tenes.
      [ ] La receta mas adecuada a los ingredientes que tenes, y los que no tenes los mas baratos.

  Tablas SQL:
    DER para ver las relaciones de cada tabla.

    [ ] @Recetas
          -*IdReceta
          - Nombre
          - Descripción
          - URLImagen
          - Tiempo_Aprox
          - Porcion
          -+IdTipo 1
          -+IdTipo 2

    [ ] @RecetaIngrediente
          -+IdReceta
          - Cantidad
          -+IdIngrediente

    [ ] @Ingredientes
          -*IdIngrediente
          - Nombre
          -+IdTipo 1
          -+IdTipo 2
          - Cantidad
          - Calorías
          - Proteínas
          - Carbohidratos
          - Grasas
          - Unidad de medida (Gramo,Unidad,Litro)
          
    [ ] @IngredienteComercio
          -+IdComercio
          -+IdIngrediente
          - Costo

    [ ] @Tipos
          -*IdTipo
          - Nombre

    [ ] @Comercio
          -*IdComercio
          - Nombre
          - Dirección
          - Horario
          - Teléfono

    [ ] @RecetaFecha
          -*IdFecha  (dateTime)
          -+IdReceta
          -+IdPerfil

    [ ] @PesoHistorico
          -*IdPesoH
          -+IdPerfil
          - Fecha
          - Peso

    [ ] @Perfiles
          -*IdPerfil
          - Nombre
          - URLAvatar


  VENTANAS:

        RECETAS:
          [ ] Ver Receta por lista de num. (Pasar recetas y ya)
          [ ] @BUSQUEDA
                [ ] Nombre Receta.
                [ ] Tipo (vegana-celiaca)
                [ ] Costo (aprox)
                [ ] CPCG
                [ ] Tiempo de cocción aprox.
                [ ] Porcion
          [ ] @EDITAR BORRAR

        LISTA DE COMPRA:
          [ ] Por Receta
          [ ] @CON INGREDIENTE
                [ ] Por Receta mas cerca de los ingrediente.
                [ ] Por Receta de coste menor cerca de los ingrediente.

          * Exportar a perfil la receta en día de hoy.
          * Ver Por donde sacar la salida (txt ?)

        PERFIL:

          [ ] @CREAR
                [ ] Nombre
                [ ] Foto
                [ ] Tipo de comida (ver si podemos bloquear los otros tipos)
                [ ] Peso Actual
                [ ] Seguridad (pass)

          [ ] @LOGIN (puede no tener pass)
                [ ] @Ver Perfil
                [ ] peso actual. (que se pueda modificar acá)
                [ ] Estadísticas de la semana
                      [ ] recetas semanales.
                      [ ] indices CPCG.

                [ ] @BUSQUEDA
                      [ ] Random vs Semana.
                      [ ] Costo vs Semana.
                      [ ] CPCG vs Semana.
                      [ ] Tipo vs Semana.
                      [ ] @INGRESAR COMIDA
                            [ ] Por Día.
                            [ ] Actual.
                            [ ] @LISTA DE COMPRA.

                [ ] @MODIFICAR PERFIL
                      [ ] PASS (protegido)
                      [ ] BORRAR

        CARGAR DATOS:

          [ ] @RECETAS
                [ ] Cargar
          [ ] @INGREDIENTES
                [ ] Cargar
          [ ] @COMERCIO
                [ ] Cargar
          [ ] @EDITAR BORRAR
                [ ] Receta
                [ ] Ingrediente
                [ ] Comercio


  BUSQUEDAS:

    [ ] @Busqueda RECETA
          [ ] Por Nombre FILTRO
          [ ] Por Tipo FILTRO
          [ ] Por Comercios FILTRO
          [ ] Ingredientes que no queres que tenga FILTRO
          [ ] Por Costo mayor menor ORDENDA
          [ ] Por Tiempo Aprox de coccion ORDENADA
          [ ] Por indice (CPCG) menor o mayor FILTRO/ORDENADA

    [ ] @Busqueda COMPRAS
          [ ] Seleccionar los ingredientes que tenes en la heladera FILTRO
          [ ] @Busqueda RECETA

    [ ] @Busqueda PERFIL
          [ ] @Busqueda RECETA
          [ ] Que no comiste en la semana FILTRO


 
  Validaciones:
    Ver bien los forms a usar.


   




       

