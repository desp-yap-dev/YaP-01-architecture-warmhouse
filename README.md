# Project_template

Это шаблон для решения проектной работы. Структура этого файла повторяет структуру заданий. Заполняйте его по мере работы над решением.

# Задание 1. Анализ и планирование

<aside>

Чтобы составить документ с описанием текущей архитектуры приложения, можно часть информации взять из описания компании и условия задания. Это нормально.

</aside

### 1. Описание функциональности монолитного приложения

**Управление отоплением:**

- Пользователи могут удаленно включать и выключать отопление в своих домах.
- Система поддерживает синхронное взаимодействие.

**Мониторинг температуры:**

- Пользователи могут просматривать текущую температуру через интерфейс. 
- Система получает данные через отправку запроса с сервера на датчик. 

### 2. Анализ архитектуры монолитного приложения

Язык программирования: Go.
База данных: PostgreSQL.
Архитектура: монолитная. Все функции реализованы внутри одного блока, нет разделений на модули по зонам ответственности. Все компоненты взаимодействуют между собой синхронно. 
Ограничения: для добавления нового устройства требуется выезд специалиста компании.

### 3. Определение доменов и границы контекстов

**AS IS:**
Домен: управление устройствами
	контекст: добавление и удаление устройств
	контекст: установка параметров устройства
Домен: мониторинг температуры
	контекст: получение данных температуры

**TO BE:**
Домен: управление пользователями
	поддомен: система авторизации и аутентификации пользователей
		контекст: логины, роли пользователей
	поддомен: добавление, блокировка, удаление пользователей
		контекст: управление пользователями
Домен: управление домами
	поддомен: добавление, блокировка, удаление домов
		контекст: управление домами
Домен: управление устройствами
	поддомен: добавление, блокировка, удаление устройств
		контекст: управление устройствами
Домен: телеметрия устройств
	поддомен: сбор и обработка данных телеметрии устройств
		контекст: обработка телеметрии
Домен: управление сценариями 
	поддомен: добавление, блокировка, удаление сценариев
		контекст: обработка сценариев

### **4. Проблемы монолитного решения**

1. Высокая связность: проблема в одном из компонентов системы может привести к останову всего приложения.
2. Отсутствие возможности частичной масштабируемости: требует масштабирования всего приложения.
3. Развертывание: требует останова всего приложения.

### 5. Визуализация контекста системы — диаграмма С4

```markdown
[Диаграмма контекста](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/Context_diagram.puml)
[Диаграмма контекста.png](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/Context_diagram.png)
```

# Задание 2. Проектирование микросервисной архитектуры

В этом задании вам нужно предоставить только диаграммы в модели C4. Мы не просим вас отдельно описывать получившиеся микросервисы и то, как вы определили взаимодействия между компонентами To-Be системы. Если вы правильно подготовите диаграммы C4, они и так это покажут.

**Диаграмма контейнеров (Containers)**

```markdown
[Диаграмма контейнеров](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/Container_diagram.puml)
[Диаграмма контейнеров.png](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/Container_diagram.png)
```

**Диаграмма компонентов (Components)**

```markdown
[Диаграмма компонентов](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/Component_diagram.puml)
[Диаграмма компонентов.png](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/Component_diagram.png)
```

**Диаграмма кода (Code)**

```markdown
[Диаграмма кода](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/Code_diagram.puml)
[Диаграмма кода.png](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/Code_diagram.png)
```

# Задание 3. Разработка ER-диаграммы

```markdown
[ER-диаграмма](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/ER_diagram.puml)
[ER-диаграмма.png](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/ER_diagram.png)
```

# Задание 4. Создание и документирование API

### 1. Тип API

В целом решение будети гибридным, поскольку будет присутствовать как прямое взаимодействие микросервисов между собой, и для таких случае лучше подходит OpenAPI, т.к. и через очередь (Kafka), где лучше подходит уже AsyncApi.

### 2. Документация API

```markdown
[Devices API](https://github.com/desp-yap-dev/YaP-01-architecture-warmhouse/blob/feature/warmhouse/schemas/swagger.json)
```

# Задание 5. Работа с docker и docker-compose

Перейдите в apps.

Там находится приложение-монолит для работы с датчиками температуры. В README.md описано как запустить решение.

Вам нужно:

1) сделать простое приложение temperature-api на любом удобном для вас языке программирования, которое при запросе /temperature?location= будет отдавать рандомное значение температуры.

Locations - название комнаты, sensorId - идентификатор названия комнаты

```
	// If no location is provided, use a default based on sensor ID
	if location == "" {
		switch sensorID {
		case "1":
			location = "Living Room"
		case "2":
			location = "Bedroom"
		case "3":
			location = "Kitchen"
		default:
			location = "Unknown"
		}
	}

	// If no sensor ID is provided, generate one based on location
	if sensorID == "" {
		switch location {
		case "Living Room":
			sensorID = "1"
		case "Bedroom":
			sensorID = "2"
		case "Kitchen":
			sensorID = "3"
		default:
			sensorID = "0"
		}
	}
```

2) Приложение следует упаковать в Docker и добавить в docker-compose. Порт по умолчанию должен быть 8081

3) Кроме того для smart_home приложения требуется база данных - добавьте в docker-compose файл настройки для запуска postgres с указанием скрипта инициализации ./smart_home/init.sql

Для проверки можно использовать Postman коллекцию smarthome-api.postman_collection.json и вызвать:

- Create Sensor
- Get All Sensors

Должно при каждом вызове отображаться разное значение температуры

Ревьюер будет проверять точно так же.


