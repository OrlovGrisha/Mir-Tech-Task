Скрипты sql запросов:
1. Выборки всех сотрудников: SELECT * FROM [Mir-Tech].[dbo].[Employees];

2. Сотрудники у кого зп выше 10000: SELECT * FROM [Mir-Tech].[dbo].[Employees]
                                    WHERE Salary > 10000;

3. Удаления сотрудников старше 70 лет: DELETE FROM [Mir-Tech].[dbo].[Employees]
                                       WHERE DATEDIFF(YEAR, Birthday, GETDATE()) > 70;

4. Обновление зп до 15000 тем сотрудникам, у которых она меньше: UPDATE [Mir-Tech].[dbo].[Employees]
                                                                 SET Salary = 100000
                                                                 WHERE Salary < 150000;

Ссылка на видео демонстрации работы приложения: https://drive.google.com/file/d/1MVzyLQIKhsYNLhCFcMR2Ez5oEqAsvj6A/view?usp=sharing
