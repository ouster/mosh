import { Router } from 'express'

const router = Router()
router.get('/', (req, res) => {
  res.send('REIMDERS!')
})

interface CreateReminderRequest {
    title: string
};

router.post('/', (req, res) => {
    const { title } = req.body as CreateReminderRequest;
    res.json(title);
}

export default router
