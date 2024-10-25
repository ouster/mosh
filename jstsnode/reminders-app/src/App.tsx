import React, { useEffect, useState } from 'react'
import './App.css'
import ReminderList from './components/ReminderList'
import Reminder from './models/reminder'
import reminderService from './services/reminder'
import NewReminder from './components/NewReminder'

function App (): JSX.Element {
  const [reminders, setReminders] = useState<Reminder[]>([
    
  ])

  useEffect(() => {
    loadReminders()
  }, [])

  const loadReminders = async () => {
    console.log('load');
    const reminders = await reminderService.getReminders()
    setReminders(reminders);
  }

  const addReminder = async (title: string) => {
    console.log(`add: ${title}`);
    const newReminder = await reminderService.addReminder(title);
    setReminders([newReminder, ...reminders]);
  }

  const deleteReminder = (id: number) => {
    console.log(`hello: ${id}`);
  }

  return (
    <div className='App'>
      <NewReminder onAddReminder={addReminder} />
      <ReminderList items={reminders} onDeleteReminder={deleteReminder} />
    </div>
  );
}

export default App

