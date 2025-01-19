global using GymManagement.Api.Endpoints;

global using GymManagement.Contracts.Subscription;
global using GymManagement.Contracts.Gyms;
global using GymManagement.Contracts.Rooms;

global using GymManagement.Infrastructure;

global using GymManagement.Application;

global using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
global using GymManagement.Application.Subscriptions.Commands.DeleteSubscription;
global using GymManagement.Application.Subscriptions.Queries.GetSubscription;

global using GymManagement.Application.Gyms.Commands.CreateGym;
global using GymManagement.Application.Gyms.Commands.DeleteGym;
global using GymManagement.Application.Gyms.Commands.AddTrainer;
global using GymManagement.Application.Gyms.Queries.ListGyms;
global using GymManagement.Application.Gyms.Queries.GetGym;

global using GymManagement.Application.Rooms.Commands.CreateRoom;
global using GymManagement.Application.Rooms.Commands.DeleteRoom;

global using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;