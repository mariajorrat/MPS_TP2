# MPS_TP2

Proyecto desarrollado para la materia Metodología de Pruebas de Sistemas (MPS), correspondiente al Trabajo Práctico 2.

## Descripción

Este repositorio implementa un sistema de gestión de productos con validaciones de negocio básicas y pruebas unitarias. La solución está dividida en dos proyectos:

- `ProductSystem`: lógica principal del sistema.
- `ProductSystem.Tests`: pruebas unitarias que validan el comportamiento esperado.

## Funcionalidades

La entidad `Product` representa un producto con los siguientes atributos:

- `Id`: identificador único del producto.
- `Name`: nombre del producto.
- `Price`: precio base del producto.
- `Category`: categoría del producto.

Se aplican las siguientes reglas de validación:

- El identificador debe ser mayor que cero.
- El nombre no puede estar vacío ni ser solo espacios.
- El precio no puede ser negativo.
- La categoría debe ser una de las siguientes:
  - `Electrónica`
  - `Alimentos`

La clase `ProductManager` gestiona la colección de productos y permite:

- agregar productos
- calcular el total con impuestos
- buscar producto por nombre
- consultar el inventario actual

## Impuestos

El costo final se calcula como:

- `Electrónica`: 10% de impuesto
- `Alimentos`: 5% de impuesto

## Pruebas realizadas

Se implementaron pruebas unitarias con NUnit para verificar:

- creación correcta de productos válidos
- rechazo de productos con valores inválidos
- cálculo del precio total según la categoría
- inserción de productos en la colección interna
- búsqueda por nombre y caso no encontrado

## Ejecución

Para ejecutar la suite de pruebas:

```bash
dotnet test MPS_TP2.slnx --nologo
```

## Resultado esperado

La solución debe pasar correctamente la validación de pruebas con un resultado de 10 pruebas ejecutadas y 10 aprobadas.
