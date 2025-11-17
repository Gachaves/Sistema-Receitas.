# Sistema de Gestão de Refeições e Receitas

Este projeto é um **aplicativo de planejamento de refeições (Meal Planner)** desenvolvido em **C#**, que permite ao usuário **gerenciar receitas, planejar menus e calcular informações nutricionais e ambientais**.

---

## 📌 Funcionalidades Principais

O sistema funciona por meio de um **menu em console**, oferecendo as seguintes ações:

### 1. Cadastro de Receita

O usuário pode:

* Inserir o **nome da receita**
* Adicionar **tags** (ex.: vegetariano, light)
* Inserir **ingredientes**, informando:

  * Calorias
  * *Environmental Impact Score* (impacto ambiental)

### 2. Listagem de Receitas

Exibe todas as receitas cadastradas no sistema.

### 3. Sugestão de Receitas

O **MealPlanner** sugere receitas com base nas **preferências informadas pelo usuário**, armazenadas na classe `User`.

### 4. Criação de Menu e Lista de Compras

O usuário pode criar um **Menu** contendo várias receitas.
O sistema gera uma **GroceryList** consolidando todos os ingredientes necessários.

### 5. Cálculo Nutricional

A classe `NutritionCalculator` soma as **calorias totais** da receita.

### 6. Cálculo de Sustentabilidade

A classe `SustainabilityCalculator` calcula a **média do impacto ambiental** dos ingredientes.

---

## 🧱 Estrutura de Classes

O programa é dividido nas seguintes classes:

* **Program**: Contém o `Main` e o menu do usuário.
* **DataStore**: Simula um banco de dados de receitas.
* **Recipe**: Armazena nome, tags e lista de ingredientes.
* **Ingredient**: Armazena nome, calorias e `EnvironmentalImpactScore`.
* **User**: Representa o usuário e suas preferências.
* **MealPlanner**: Lógica de sugestão de receitas.
* **Menu**: Agrupa um conjunto de receitas.
* **GroceryList**: Gera e imprime a lista de ingredientes consolidada.
* **NutritionCalculator** e **SustainabilityCalculator**: Executam cálculos específicos.

📌 **Total de métodos no projeto:** 26.

---

## 🛠️ Tecnologias Utilizadas

* **C#**
* **.NET 8**
* **Visual Studio**
* **ReportGenerator**
  [https://github.com/danielpalme/ReportGenerator](https://github.com/danielpalme/ReportGenerator)
* **XUnit**
* **GitHub do projeto:**
  [https://github.com/Gachaves/Sistema-de-Gest-o-Refei-es-e-Receitas..git](https://github.com/Gachaves/Sistema-de-Gest-o-Refei-es-e-Receitas..git)

---

## 🧪 Cálculo de Teste
<img width="1143" height="600" alt="image" src="https://github.com/user-attachments/assets/8b3ff3a8-4932-47ac-8201-5a02d23f733c" />

<img width="1138" height="604" alt="image" src="https://github.com/user-attachments/assets/0c828439-20ec-4530-a8a8-11c36055d655" />

<img width="855" height="661" alt="image" src="https://github.com/user-attachments/assets/fc54dc34-4aef-4194-84d7-57a4d3055e07" />
