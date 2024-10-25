import axios from 'axios'
import Reminder from '../models/reminder'

class ReminderService {
  http = axios.create({ baseURL: 'https://jsonplaceholder.typicode.com/' })

  async getReminders () {
    return (await this.http.get<Reminder[]>('/todos')).data
  }

  async addReminder (title: string) {
    return (await this.http.post<Reminder>('/todos', { title })).data
  }

  async deleteReminder (id: number) {
    return (await this.http.delete(`/todos/${id}`)).data
  }
}

const reminderService = new ReminderService()
export default reminderService
