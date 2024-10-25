import React from 'react'
import Reminder from '../models/reminder'

interface ReminderListProps {
  items: Reminder[]
  onDeleteReminder: (id: number) => void
}

function ReminderList ({ items, onDeleteReminder }: ReminderListProps) {
  return (
    <ul className='list-group'>
      {items.map(item => (
        <li className='list-group-item' key={item.id}>
          {item.title}
          <button
            onClick={() => onDeleteReminder(item.id)}
            className='btn btn-outline-danger mx-2 btn-sm float'
          >
            Delete
          </button>
        </li>
      ))}
    </ul>
  )
}

export default ReminderList
