Proyecto queComemos:

  Idea:

    QueComemos es una aplicación pensada para esos momentos donde no se sabe que comer en la casa. La aplicación permite manejar recetas precargadas, para realizar búsquedas que nos ayuden a evaluar que comida vamos a hacer. Permite búsquedas de tiempo de preparación, costo, cantidad de macro-nutrientes (proteínas,carbohidratos,calorías,grasas), tipo de comidas (vegetarianas,veganas, celiacas,etc.),por ingredientes en la heladera, por nombre.

    También provee una base de datos de comercios para cargar costos especifico, ver sus horarios y días hábiles.(si los teléfonos de delivery también están incluidos)

    La aplicación permite también , de modo opcional, gestionar un perfil en el cual podamos seguir las comidas, la nutrición y el peso en plazo de una semana o mas. (incluye gráficos para ir viendo lo que vamos consumiendo en macro-nutrientes y el peso semanal)



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


 



   




       

